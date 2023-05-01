using Microsoft.Extensions.DependencyInjection;

namespace Chronicle.Core;
/// <summary>
/// A provider of Chronicle plugins.
/// </summary>

public interface IChroniclePluginProvider {
  /// <summary>
  /// Register the provider's services with the service collection.
  /// </summary>
  public IServiceCollection Register(IServiceCollection serviceCollection);
}
