namespace Chronicle.Core.Model.Configuration;

/// <summary>
/// A raw group of backup tasks (not fully resolved).
/// </summary>
/// <param name="Name">Name of the group</param>
/// <param name="Recurrence">How often the group is executed</param>
/// <param name="Tasks">Backup tasks in the group</param>
/// <param name="Sinks">Backup sinks in the group</param>
public record BackupTaskGroup(string Name, Recurrence Recurrence, List<BackupTask> Tasks, List<BackupSink> Sinks);
