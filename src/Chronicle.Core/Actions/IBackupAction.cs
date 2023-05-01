namespace Chronicle.Core.Actions;

using Chronicle.Core.Model;
using Chronicle.Core.Model.Configuration.Settings;
using CSharpFunctionalExtensions;

/// <summary>
/// An action that backs up the data of the system.
/// </summary>
public interface IBackupAction {
  /// <summary>
  /// Try to resolve the given dictionary as settings appropriate for this action.
  /// </summary>
  /// <returns>A result with resolved settings</returns>
  Result<IActionSettings> ResolveActionSettings(Dictionary<string, object> settings);

  /// <summary>This action supports verifying a backup.</summary>
  bool SupportsVerify(IActionSettings settings);

  /// <summary>This action supports restoring a backup.</summary>
  bool SupportsRestore(IActionSettings settings);

  /// <summary>This action supports restoring a backup that is not stored on the file system, but that is provided as a string, as a byte array, or as a stream.</summary>
  bool SupportsRestoreWithoutFiles(IActionSettings settings);

  /// <summary>Returns the output type this backup action supports.</summary>
  OutputType SupportedOutputType(IActionSettings settings);

  /// <summary>Back up the data.</summary>
  /// <param name="settings">Settings of the action</param>
  /// <param name="outputDetails">Details of the expected output stream and data</param>
  /// <returns>A result with the backed-up data</returns>
  Task<Result<IBackupData>> Backup(IActionSettings settings, IOutputDetails outputDetails);

  /// <summary>Verify the backup data, without making any changes to the backed-up system.</summary>
  /// <param name="settings">Settings of the action</param>
  /// <param name="backupData">Backed up data</param>
  /// <exception cref="NotSupportedException">This plugin does not support verifying this backup</exception>
  /// <returns>A result with verification results (success if the data is valid)</returns>
  Task<Result> Verify(IActionSettings settings, IBackupData backupData);

  /// <summary>Restore the backup data.</summary>
  /// <param name="settings">Settings of the action</param>
  /// <param name="backupData">Backed up data</param>
  /// <exception cref="NotSupportedException">This plugin does not support restoring this backup</exception>
  /// <returns>A result with restore results (success if the data is was restored successfully)</returns>
  Task<Result> Restore(IActionSettings settings, IBackupData backupData);
}
