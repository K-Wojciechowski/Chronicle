using Chronicle.Core.Model.Configuration.Settings;
using CSharpFunctionalExtensions;

namespace Chronicle.Core.Sinks;

/// <summary>
/// An output sink for backed up data.
/// </summary>
public interface IOutputSink {
  /// <summary>
  /// Try to resolve the given dictionary as settings appropriate for this sink.
  /// </summary>
  /// <returns>A result with resolved settings</returns>
  Result<ISinkSettings> ResolveSinkSettings(Dictionary<string, object> settings);

  /// <summary>Start writing data for a group to the sink.</summary>
  /// <param name="executionId">Unique ID of this session</param>
  /// <param name="friendlyId">Friendly ID of this session</param>
  /// <param name="groupName">Name of the group</param>
  /// <param name="startTime">Start time of the group</param>
  /// <param name="settings">Sink settings</param>
  /// <returns>An output session object</returns>
  Task<Result<IOutputSession>> StartSession(Guid executionId, string friendlyId, string groupName, DateTimeOffset startTime, ISinkSettings settings);

  /// <summary>Write a single item to the sink, taking a stream as an input.</summary>
  /// <param name="session">Output session</param>
  /// <param name="itemPath">Path to item (in output)</param>
  /// <param name="stream">Stream with item data</param>
  Task<Result> WriteStream(IOutputSession session, string itemPath, Stream stream);

  /// <summary>Write a single item to the sink, taking a file path as an input.</summary>
  /// <param name="session">Output session</param>
  /// <param name="itemPath">Path to item (in output)</param>
  /// <param name="filePath">Path to file (on local filesystem)</param>
  Task<Result> WriteFile(IOutputSession session, string itemPath, string filePath);

  /// <summary>Write a single item to the sink, taking a file path as an input.</summary>
  /// <param name="session">Output session</param>
  /// <param name="receipt">A data stream that describes the session, which should be stored alongside the written items</param>
  Task<Result> EndSession(IOutputSession session, byte[] receipt);

  /// <summary>Suggest a filesystem path to which the item should be written (which would allow the output sink to avoid excessively copying data).</summary>
  /// <param name="session">Output session</param>
  /// <param name="itemPath">Path to item (in output)</param>
  /// <returns>Suggested filesystem path, or null if no preferences</returns>
  string? SuggestPath(IOutputSession session, string itemPath);

  // TODO: Reading backup data from sink
}
