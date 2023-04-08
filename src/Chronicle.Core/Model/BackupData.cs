namespace Chronicle.Core.Model;

/// <summary>
/// Marker interface for backup data containers.
/// </summary>
public interface IBackupData {
}

/// <summary>
/// Backup data in text format.
/// </summary>
/// <param name="TextData">Backed-up text</param>
public record TextBackupData(string TextData) : IBackupData;

/// <summary>
/// Backup data in binary format.
/// </summary>
/// <param name="BinaryData">Backed-up bytes</param>
public record BinaryBackupData(byte[] BinaryData) : IBackupData;

/// <summary>
/// Backup data in stream format.
/// </summary>
/// <param name="StreamData">Backed-up data as a stream</param>
public record StreamBackupData(Stream StreamData) : IBackupData;

/// <summary>
/// Backup data stored in a file on the filesystem.
/// </summary>
/// <param name="FilePath">Path to backed-up data on the local filesystem </param>
public record FileBackupData(string FilePath) : IBackupData;
