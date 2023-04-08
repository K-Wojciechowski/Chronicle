namespace Chronicle.Core.Model.Configuration;

/// <summary>
/// A group of backup tasks.
/// </summary>
/// <param name="Name">Name of the group</param>
/// <param name="Recurrence">How often the group is executed</param>
/// <param name="TaskNames">Names of tasks in the group</param>
/// <param name="SinkNames">Names of sinks in the group</param>
public record BackupTaskGroup(string Name, Recurrence Recurrence, List<string> TaskNames, List<string> SinkNames);
