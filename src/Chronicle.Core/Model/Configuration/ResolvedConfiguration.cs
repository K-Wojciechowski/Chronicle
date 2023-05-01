namespace Chronicle.Core.Model.Configuration;

/// <summary>
/// Resolved Chronicle configuration.
/// </summary>
/// <param name="Tasks">All configured tasks</param>
/// <param name="Sinks">All configured sinks</param>
/// <param name="Groups">All configured task groups</param>
public record ResolvedConfiguration(Dictionary<string, BackupTask> Tasks, Dictionary<string, BackupSink> Sinks, Dictionary<string, BackupTaskGroup> Groups);
