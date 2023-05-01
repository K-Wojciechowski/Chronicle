namespace Chronicle.Core.Model.Configuration.Raw;

/// <summary>
/// A raw group of backup tasks (not fully resolved).
/// </summary>
/// <param name="Name">Name of the group</param>
/// <param name="Recurrence">How often the group is executed</param>
/// <param name="Tasks">Names of tasks in the group</param>
/// <param name="Sinks">Names of sinks in the group</param>
public record RawBackupTaskGroup(string Name, Recurrence Recurrence, List<string> Tasks, List<string> Sinks);
