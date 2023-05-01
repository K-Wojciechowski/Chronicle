namespace Chronicle.Core.Sinks;

/// <summary>
/// The marker interface for an output session. 
/// Classes implementing this interface should contain the data needed by the output sink to write new items.
/// </summary>
public interface IOutputSession {
}

/// <summary>
/// A basic output session.
/// </summary>
/// <param name="Destination">Destination of the data</param>
public record OutputSession(string Destination);
