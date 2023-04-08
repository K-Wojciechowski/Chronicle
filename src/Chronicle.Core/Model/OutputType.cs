namespace Chronicle.Core.Model;

/// <summary>
/// The output type of a backup action.
/// </summary>
public enum OutputType {
  /// <summary>The backup action produces a single string.</summary>
  Text,

  /// <summary>The backup action produces a single byte array.</summary>
  Binary,

  /// <summary>The backup action produces a <see cref="Stream" />.</summary>
  Stream,

  /// <summary>The backup action writes to a file, whose path is provided to it by the tool.</summary>
  ProvidedFile,

  /// <summary>The backup action writes to a file, whose path is determined by the backup action itself.</summary>
  CustomFile
}
