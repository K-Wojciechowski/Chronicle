namespace Chronicle.Core.Model;

/// <summary>
/// Recurrence of a backup task group.
/// </summary>
public enum Recurrence {
  /// <summary>Run the task group every hour.</summary>
  Hourly,

  /// <summary>Run the task group every day.</summary>
  Daily,

  /// <summary>Run the task group every week.</summary>
  Weekly,

  /// <summary>Run the task group every two weeks.</summary>
  Fortnightly,

  /// <summary>Run the task group every month.</summary>
  Monthly,

  /// <summary>Run the task group manually.</summary>
  Manual
}
