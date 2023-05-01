using Chronicle.Core;
using CSharpFunctionalExtensions;

namespace Chronicle.ConfigResolver;
internal interface IPluginLoader {
  /// <summary>
  /// Discover plugin providers.
  /// </summary>
  /// <param name="customPluginProviders">List of configured custom plugin providers</param>
  /// <returns>List of plugin provider instances or error</returns>
  public Result<IEnumerable<IChroniclePluginProvider>> DiscoverPluginProviders(IEnumerable<string> customPluginProviders);
}
