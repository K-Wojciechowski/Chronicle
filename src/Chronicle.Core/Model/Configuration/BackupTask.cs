namespace Chronicle.Core.Model.Configuration;

/// <summary>
/// A backup task.
/// </summary>
/// <param name="Name">Name of the task</param>
/// <param name="Plugin">Plugin providing the task</param>
/// <param name="Settings">Settings for the task</param>
public record BackupTask(string Name, string Plugin, ISettings Settings);
