using Chronicle.Core.Actions;
using Chronicle.Core.Model.Configuration.Settings;

namespace Chronicle.Core.Model.Configuration;

/// <summary>
/// A backup task.
/// </summary>
/// <param name="Name">Name of the task</param>
/// <param name="Action">Action associated with the task</param>
/// <param name="Settings">Settings for the task</param>
public record BackupTask(string Name, IBackupAction Action, IActionSettings Settings);
