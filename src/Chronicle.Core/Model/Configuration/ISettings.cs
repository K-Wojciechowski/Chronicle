namespace Chronicle.Core.Model.Configuration;

/// <summary>
/// A basic interface for settings.
/// </summary>
public interface ISettings {
  /// <summary>Priority of the task, defaults to 0. Tasks with the same priority may be executed in parallel.</summary>
  public int Priority { get; init; }

  /// <summary>Does the task require superuser permissions?</summary>
  public bool Sudo { get; init; }
}

