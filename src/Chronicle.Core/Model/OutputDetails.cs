namespace Chronicle.Core.Model;

/// <summary>
/// Details about the current output.
/// </summary>
public interface IOutputDetails {
  /// <summary>Name of the task</summary>
  string TaskName { get; }

  /// <summary>Name of the task group</summary>
  string GroupName { get; }

  /// <summary>Timestamp when backup execution started</summary>
  DateTimeOffset StartTime { get; }
}

/// <summary>
/// Details about a memory-based output.
/// </summary>
/// <param name="TaskName">Name of the task</param>
/// <param name="GroupName">Name of the task group</param>
/// <param name="StartTime">Timestamp when backup execution started</param>
public record MemoryOutputDetails(string TaskName, string GroupName, DateTimeOffset StartTime) : IOutputDetails;

/// <summary>
/// Details about a file output.
/// </summary>
/// <param name="TaskName">Name of the task</param>
/// <param name="GroupName">Name of the task group</param>
/// <param name="StartTime">Timestamp when backup execution started</param>
/// <param name="OutputFilePath">File to which output should be written</param>
public record FileOutputDetails(string TaskName, string GroupName, DateTimeOffset StartTime, string OutputFilePath) : IOutputDetails;
