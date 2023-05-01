namespace Chronicle.Core.Model.Configuration.Raw;

/// <summary>
/// Raw Chronicle configuration, as stored in the YAML files.
/// </summary>
/// <param name="Tasks">All configured tasks</param>
/// <param name="Sinks">All configured sinks</param>
/// <param name="Groups">All configured task groups</param>
/// <param name="CustomPluginProviders">Assemblies that contain custom plugins</param>
public record RawConfiguration(List<RawBackupItem> Tasks, List<RawBackupItem> Sinks, List<RawBackupTaskGroup> Groups, List<string>? CustomPluginProviders);
