namespace Chronicle.Core.Actions;

using Chronicle.Core.Model;
using Chronicle.Core.Model.Configuration.Settings;
using CSharpFunctionalExtensions;

/// <summary>
/// A backup action that outputs text.
/// </summary>
public abstract class TextBackupAction : IBackupAction {
  /// <inheritdoc />
  public OutputType SupportedOutputType(IActionSettings settings) => OutputType.Text;
  /// <inheritdoc />
  public bool SupportsRestoreWithoutFiles(IActionSettings settings) => true;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract Result<IActionSettings> ResolveActionSettings(Dictionary<string, object> settings);

  /// <inheritdoc />
  public abstract bool SupportsRestore(IActionSettings settings);
  /// <inheritdoc />
  public abstract bool SupportsVerify(IActionSettings settings);

  /// <inheritdoc />
  public abstract Task<Result<IBackupData>> Backup(IActionSettings settings, IOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(IActionSettings settings, IBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(IActionSettings settings, IBackupData backupData);
}

/// <summary>
/// A backup action that outputs binary data.
/// </summary>
public abstract class BinaryBackupAction : IBackupAction {
  /// <inheritdoc />
  public OutputType SupportedOutputType(IActionSettings settings) => OutputType.Binary;
  /// <inheritdoc />
  public bool SupportsRestoreWithoutFiles(IActionSettings settings) => true;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract Result<IActionSettings> ResolveActionSettings(Dictionary<string, object> settings);

  /// <inheritdoc />
  public abstract bool SupportsRestore(IActionSettings settings);
  /// <inheritdoc />
  public abstract bool SupportsVerify(IActionSettings settings);

  /// <inheritdoc />
  public abstract Task<Result<IBackupData>> Backup(IActionSettings settings, IOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(IActionSettings settings, IBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(IActionSettings settings, IBackupData backupData);
}

/// <summary>
/// A backup action that outputs a stream.
/// </summary>
public abstract class StreamBackupAction : IBackupAction {
  /// <inheritdoc />
  public OutputType SupportedOutputType(IActionSettings settings) => OutputType.Stream;
  /// <inheritdoc />
  public bool SupportsRestoreWithoutFiles(IActionSettings settings) => true;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract Result<IActionSettings> ResolveActionSettings(Dictionary<string, object> settings);

  /// <inheritdoc />
  public abstract bool SupportsRestore(IActionSettings settings);
  /// <inheritdoc />
  public abstract bool SupportsVerify(IActionSettings settings);

  /// <inheritdoc />
  public abstract Task<Result<IBackupData>> Backup(IActionSettings settings, IOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(IActionSettings settings, IBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(IActionSettings settings, IBackupData backupData);
}

/// <summary>
/// A backup action that outputs a file at a location provided by the system.
/// </summary>
public abstract class ProvidedFileBackupAction : IBackupAction {
  /// <inheritdoc />
  public OutputType SupportedOutputType(IActionSettings settings) => OutputType.ProvidedFile;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract Result<IActionSettings> ResolveActionSettings(Dictionary<string, object> settings);

  /// <inheritdoc />
  public abstract bool SupportsVerify(IActionSettings settings);
  /// <inheritdoc />
  public abstract bool SupportsRestore(IActionSettings settings);
  /// <inheritdoc />
  public abstract bool SupportsRestoreWithoutFiles(IActionSettings settings);

  /// <inheritdoc />
  public abstract Task<Result<IBackupData>> Backup(IActionSettings settings, IOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(IActionSettings settings, IBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(IActionSettings settings, IBackupData backupData);
}

/// <summary>
/// A backup action that outputs a file at a location of its own choosing.
/// </summary>
public abstract class CustomFileBackupAction : IBackupAction {
  /// <inheritdoc />
  public OutputType SupportedOutputType(IActionSettings settings) => OutputType.CustomFile;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract Result<IActionSettings> ResolveActionSettings(Dictionary<string, object> settings);

  /// <inheritdoc />
  public abstract bool SupportsVerify(IActionSettings settings);
  /// <inheritdoc />
  public abstract bool SupportsRestore(IActionSettings settings);
  /// <inheritdoc />
  public abstract bool SupportsRestoreWithoutFiles(IActionSettings settings);

  /// <inheritdoc />
  public abstract Task<Result<IBackupData>> Backup(IActionSettings settings, IOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(IActionSettings settings, IBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(IActionSettings settings, IBackupData backupData);
}
