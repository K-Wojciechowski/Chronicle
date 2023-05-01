using Chronicle.Core.Actions;
using Chronicle.Core.Sinks;
using Microsoft.Extensions.DependencyInjection;

namespace Chronicle.Core;

/// <summary>
/// A simple plugin registry that automatically registers a list of types.
/// </summary>
public abstract class SimpleChroniclePluginProvider : IChroniclePluginProvider {
  /// <summary>
  /// Actions and Sinks that are part of the registry.
  /// </summary>
  public abstract IReadOnlyList<Type> Types { get; }

  /// <inheritdoc/>
  public IServiceCollection Register(IServiceCollection services) {
    var backupActionType = typeof(IBackupAction);
    var outputSinkType = typeof(IOutputSink);
    foreach (var type in Types) {
      if (type.IsSubclassOf(backupActionType)) {
        services.AddSingleton(backupActionType, type);
      } else if (type.IsSubclassOf(outputSinkType)) {
        services.AddSingleton(backupActionType, type);
      } else {
        services.AddSingleton(type, type);
      }
    }
    return services;
  }
}
