using Chronicle.CommonPlugins;
using Chronicle.Core;
using CSharpFunctionalExtensions;

namespace Chronicle.ConfigResolver;

internal class CommonPluginLoader : IPluginLoader {
  public static IEnumerable<IChroniclePluginProvider> _providers = new[] { new CommonPluginProvider() };

  private static Result<IEnumerable<IChroniclePluginProvider>> _providersResult = Result.Success(_providers);

  public Result<IEnumerable<IChroniclePluginProvider>> DiscoverPluginProviders(IEnumerable<string> customPluginProviders) => _providersResult;
}
