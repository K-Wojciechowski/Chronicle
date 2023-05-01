namespace Chronicle.Core.Model.Configuration.Settings;

/// <summary>
/// A basic interface for task/action settings.
/// </summary>
public interface IActionSettings {
  /// <summary>Priority of the task, defaults to 0. Tasks with the same non-zero priority may be executed in parallel. Tasks with the highest priority execute first.</summary>
  public int Priority { get; init; }

  /// <summary>Does the action require superuser permissions?</summary>
  public bool Sudo { get; init; }
}

