namespace Chronicle.Core.Actions;

using System.Runtime.CompilerServices;
using Chronicle.Core.Model;
using Chronicle.Core.Model.Configuration;
using CSharpFunctionalExtensions;

/// <summary>
/// A backup action that outputs text.
/// </summary>
public abstract class TextBackupAction : IBackupAction<TextBackupData, MemoryOutputDetails> {
  /// <inheritdoc />
  public OutputType SupportedOutputType(ISettings settings) => OutputType.Text;
  /// <inheritdoc />
  public bool SupportsRestoreWithoutFiles(ISettings settings) => true;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract bool SupportsRestore(ISettings settings);
  /// <inheritdoc />
  public abstract bool SupportsVerify(ISettings settings);

  /// <inheritdoc />
  public abstract Task<Result<TextBackupData>> Backup(ISettings settings, MemoryOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(ISettings settings, TextBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(ISettings settings, TextBackupData backupData);
}

/// <summary>
/// A backup action that outputs binary data.
/// </summary>
public abstract class BinaryBackupAction : IBackupAction<BinaryBackupData, MemoryOutputDetails> {
  /// <inheritdoc />
  public OutputType SupportedOutputType(ISettings settings) => OutputType.Binary;
  /// <inheritdoc />
  public bool SupportsRestoreWithoutFiles(ISettings settings) => true;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract bool SupportsRestore(ISettings settings);
  /// <inheritdoc />
  public abstract bool SupportsVerify(ISettings settings);

  /// <inheritdoc />
  public abstract Task<Result<BinaryBackupData>> Backup(ISettings settings, MemoryOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(ISettings settings, BinaryBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(ISettings settings, BinaryBackupData backupData);
}

/// <summary>
/// A backup action that outputs a stream.
/// </summary>
public abstract class StreamBackupAction : IBackupAction<StreamBackupData, MemoryOutputDetails> {
  /// <inheritdoc />
  public OutputType SupportedOutputType(ISettings settings) => OutputType.Stream;
  /// <inheritdoc />
  public bool SupportsRestoreWithoutFiles(ISettings settings) => true;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract bool SupportsRestore(ISettings settings);
  /// <inheritdoc />
  public abstract bool SupportsVerify(ISettings settings);

  /// <inheritdoc />
  public abstract Task<Result<StreamBackupData>> Backup(ISettings settings, MemoryOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(ISettings settings, StreamBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(ISettings settings, StreamBackupData backupData);
}

/// <summary>
/// A backup action that outputs a file at a location provided by the system.
/// </summary>
public abstract class ProvidedFileBackupAction : IBackupAction<FileBackupData, FileOutputDetails> {
  /// <inheritdoc />
  public OutputType SupportedOutputType(ISettings settings) => OutputType.ProvidedFile;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract bool SupportsVerify(ISettings settings);
  /// <inheritdoc />
  public abstract bool SupportsRestore(ISettings settings);
  /// <inheritdoc />
  public abstract bool SupportsRestoreWithoutFiles(ISettings settings);

  /// <inheritdoc />
  public abstract Task<Result<FileBackupData>> Backup(ISettings settings, FileOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(ISettings settings, FileBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(ISettings settings, FileBackupData backupData);
}

/// <summary>
/// A backup action that outputs a file at a location of its own choosing.
/// </summary>
public abstract class CustomFileBackupAction : IBackupAction<FileBackupData, FileOutputDetails> {
  /// <inheritdoc />
  public OutputType SupportedOutputType(ISettings settings) => OutputType.CustomFile;

  // Remaining methods should be defined by the specific action.

  /// <inheritdoc />
  public abstract bool SupportsVerify(ISettings settings);
  /// <inheritdoc />
  public abstract bool SupportsRestore(ISettings settings);
  /// <inheritdoc />
  public abstract bool SupportsRestoreWithoutFiles(ISettings settings);

  /// <inheritdoc />
  public abstract Task<Result<FileBackupData>> Backup(ISettings settings, FileOutputDetails outputDetails);
  /// <inheritdoc />
  public abstract Task<Result> Restore(ISettings settings, FileBackupData backupData);
  /// <inheritdoc />
  public abstract Task<Result> Verify(ISettings settings, FileBackupData backupData);
}
