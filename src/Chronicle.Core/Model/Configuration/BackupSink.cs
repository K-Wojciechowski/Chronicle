using Chronicle.Core.Model.Configuration.Settings;
using Chronicle.Core.Sinks;

namespace Chronicle.Core.Model.Configuration;

/// <summary>
/// A sink for backup data.
/// </summary>
/// <param name="Name">Name of the sink</param>
/// <param name="OutputSink">The output sink</param>
/// <param name="Settings">Settings for the sink</param>
public record BackupSink(string Name, IOutputSink OutputSink, ISinkSettings Settings);
