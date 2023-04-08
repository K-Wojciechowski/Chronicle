namespace Chronicle.Core.Actions;

using Chronicle.Core.Model;
using Chronicle.Core.Model.Configuration;
using CSharpFunctionalExtensions;

/// <summary>
/// An action that backs up the data of the system.
/// </summary>
/// <typeparam name="TBackupData">An interface for encapsulating backup data produced by this action</typeparam>
/// <typeparam name="TOutputDetails">An interface describing the expected output data</typeparam>
public interface IBackupAction<TBackupData, TOutputDetails>
  where TBackupData : class, IBackupData
  where TOutputDetails : class, IOutputDetails {
  /// <summary>This action supports verifying a backup.</summary>
  bool SupportsVerify(ISettings settings);

  /// <summary>This action supports restoring a backup.</summary>
  bool SupportsRestore(ISettings settings);

  /// <summary>This action supports restoring a backup that is not stored on the file system, but that is provided as a string, as a byte array, or as a stream.</summary>
  bool SupportsRestoreWithoutFiles(ISettings settings);

  /// <summary>Returns the output type this backup action supports.</summary>
  OutputType SupportedOutputType(ISettings settings);

  /// <summary>Back up the data.</summary>
  /// <param name="settings">Settings of the action</param>
  /// <param name="outputDetails">Details of the expected output stream and data</param>
  /// <returns>A result with the backed-up data</returns>
  Task<Result<TBackupData>> Backup(ISettings settings, TOutputDetails outputDetails);

  /// <summary>Verify the backup data, without making any changes to the backed-up system.</summary>
  /// <param name="settings">Settings of the action</param>
  /// <param name="backupData">Backed up data</param>
  /// <exception cref="NotSupportedException">This plugin does not support verifying this backup</exception>
  /// <returns>A result with verification results (success if the data is valid)</returns>
  Task<Result> Verify(ISettings settings, TBackupData backupData);

  /// <summary>Restore the backup data.</summary>
  /// <param name="settings">Settings of the action</param>
  /// <param name="backupData">Backed up data</param>
  /// <exception cref="NotSupportedException">This plugin does not support restoring this backup</exception>
  /// <returns>A result with restore results (success if the data is was restored successfully)</returns>
  Task<Result> Restore(ISettings settings, TBackupData backupData);
}
