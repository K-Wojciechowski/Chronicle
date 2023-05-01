namespace Chronicle.Core.Model.Configuration.Raw;

/// <summary>
/// A raw (unparsed) configuration item. Can be parsed to <see cref="BackupSink"/> or <see cref="BackupTask"/>.
/// </summary>
/// <param name="Name">Name of the item</param>
/// <param name="Plugin">Plugin providing the item</param>
/// <param name="Settings">Settings for the item</param>
public record RawBackupItem(string Name, string Plugin, Dictionary<string, object> Settings);
