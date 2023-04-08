using Chronicle.Core.Model.Configuration;

namespace Chronicle.Core.Model;

/// <summary>
/// A sink for backup data.
/// </summary>
/// <param name="Name">Name of the sink</param>
/// <param name="Plugin">Plugin providing the sink</param>
/// <param name="Settings">Settings for the sink</param>
public record BackupSink(string Name, string Plugin, ISettings Settings);
