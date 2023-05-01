using Chronicle.Core.Actions;
using Chronicle.Core.Model.Configuration;
using Chronicle.Core.Model.Configuration.Raw;
using Chronicle.Core.Sinks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace Chronicle.ConfigResolver;

class BasicConfigResolver : IConfigResolver {
  public Result<ResolvedConfiguration> Resolve(RawConfiguration rawConfiguration, ServiceProvider serviceProvider) {
    var itemResolutionContext = new ItemResolutionContext(serviceProvider);

    var tasksResult = rawConfiguration.Tasks.Select(itemResolutionContext.ResolveTask).Combine("\n");
    var sinksResult = rawConfiguration.Tasks.Select(itemResolutionContext.ResolveSink).Combine("\n");

    if (tasksResult.IsFailure || sinksResult.IsFailure) {
      var errors = new[] {
        tasksResult.IsFailure ? tasksResult.Error : null,
        sinksResult.IsFailure ? sinksResult.Error : null
      };
      return Result.Failure<ResolvedConfiguration>(string.Join('\n', errors.Where(x => x != null)));
    }

    var tasks = tasksResult.Value.ToDictionary(i => i.Name, i => i, StringComparer.InvariantCultureIgnoreCase);
    var sinks = sinksResult.Value.ToDictionary(i => i.Name, i => i, StringComparer.InvariantCultureIgnoreCase);

    var groupResolutionContext = new GroupResolutionContext(tasks, sinks);
    var groupsResult = rawConfiguration.Groups.Select(groupResolutionContext.ResolveGroup).Combine("\n");
    return groupsResult
      .Map(groups => groups.ToDictionary(g => g.Name, g => g, StringComparer.InvariantCultureIgnoreCase))
      .Map(groupsDict => new ResolvedConfiguration(tasks, sinks, groupsDict));
  }

  private class ItemResolutionContext {
    private readonly Dictionary<string, IBackupAction> _actionProviders;
    private readonly Dictionary<string, IOutputSink> _sinkProviders;

    public ItemResolutionContext(ServiceProvider serviceProvider) {
      _actionProviders = BuildDictionary(serviceProvider.GetServices<IBackupAction>());
      _sinkProviders = BuildDictionary(serviceProvider.GetServices<IOutputSink>());
    }

    public Result<BackupTask> ResolveTask(RawBackupItem rawItem) {
      var name = rawItem.Name;
      var hasAction = _actionProviders.TryGetValue(rawItem.Plugin, out var action);
      if (!hasAction) return Result.Failure<BackupTask>($"Task {name} uses unrecognized plugin {rawItem.Plugin}");
      var settingsResult = action!.ResolveActionSettings(rawItem.Settings);
      return settingsResult.Match(
        onSuccess: settings => new BackupTask(name, action, settings),
        onFailure: e => Result.Failure<BackupTask>($"Task {name} failed to resolve settings: {e}")
      );
    }

    public Result<BackupSink> ResolveSink(RawBackupItem rawItem) {
      var name = rawItem.Name;
      var hasSink = _sinkProviders.TryGetValue(rawItem.Plugin, out IOutputSink? sink);
      if (!hasSink) return Result.Failure<BackupSink>($"Sink {name} uses unrecognized plugin {rawItem.Plugin}");
      var settingsResult = sink!.ResolveSinkSettings(rawItem.Settings);
      return settingsResult.Match(
        onSuccess: settings => new BackupSink(name, sink, settings),
        onFailure: e => Result.Failure<BackupSink>($"Sink {name} failed to resolve settings: {e}")
      );
    }

    private Dictionary<string, T> BuildDictionary<T>(IEnumerable<T> services)
      => services.ToDictionary(i => i!.GetType().Name, i => i, StringComparer.InvariantCultureIgnoreCase);
  }

  private class GroupResolutionContext {
    private readonly Dictionary<string, BackupTask> _tasks;
    private readonly Dictionary<string, BackupSink> _sinks;

    public GroupResolutionContext(Dictionary<string, BackupTask> tasks, Dictionary<string, BackupSink> sinks) {
      _tasks = tasks;
      _sinks = sinks;
    }

    public Result<BackupTaskGroup> ResolveGroup(RawBackupTaskGroup rawGroup) {
      var name = rawGroup.Name;
      var taskResult = rawGroup.Tasks.Select(FindBackupTask).Combine("\n");
      var sinkResult = rawGroup.Tasks.Select(FindBackupSink).Combine("\n");

      if (taskResult.IsFailure || sinkResult.IsFailure) {
        var errors = new[] {
          taskResult.IsFailure ? taskResult.Error : null,
          sinkResult.IsFailure ? sinkResult.Error : null
        };
        return Result.Failure<BackupTaskGroup>($"While resolving group {name}:\n" + string.Join('\n', errors.Where(x => x != null)));
      }

      var tasks = taskResult.Value.ToList();
      var sinks = sinkResult.Value.ToList();
      return new BackupTaskGroup(name, rawGroup.Recurrence, tasks, sinks);
    }

    public Result<BackupTask> FindBackupTask(string name) {
      return
        _tasks.TryGetValue(name, out var task)
        ? task
        : Result.Failure<BackupTask>($"Task {task} listed in group but not defined.");
    }

    public Result<BackupSink> FindBackupSink(string name) {
      return
        _sinks.TryGetValue(name, out var sink)
        ? sink
        : Result.Failure<BackupSink>($"Sink {sink} listed in group but not defined.");
    }
  }
}
