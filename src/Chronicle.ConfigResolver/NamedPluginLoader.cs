using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Chronicle.Core;
using CSharpFunctionalExtensions;

namespace Chronicle.ConfigResolver;
internal class NamedPluginLoader : IPluginLoader {
  private static readonly Type _targetType = typeof(IChroniclePluginProvider);

  public Result<IEnumerable<IChroniclePluginProvider>> DiscoverPluginProviders(IEnumerable<string> customPluginProviders)
    => customPluginProviders.Select(LoadAssembly)
      .Combine("\n\n")
      .Bind(assemblies => assemblies.Select(DiscoverProvidersInAssembly).Combine("\n\n"))
      .Map(nestedEnumerable => nestedEnumerable.SelectMany(e => e));

  private Result<IEnumerable<IChroniclePluginProvider>> DiscoverProvidersInAssembly(Assembly assembly) {
    var qualifyingTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(_targetType));

    if (!qualifyingTypes.Any()) {
      return Result.Failure<IEnumerable<IChroniclePluginProvider>>($"No providers found in assembly {assembly}");
    }

    try {
      return qualifyingTypes
        .Select(Activator.CreateInstance)
        .Cast<IChroniclePluginProvider>()
        .ToList();
    } catch (Exception e) {
      return Result.Failure<IEnumerable<IChroniclePluginProvider>>($"Unable to activate providers in assembly {assembly}: {e.Message}\n{e.StackTrace}");
    }
  }

  private Result<Assembly> LoadAssembly(string name) {
    try {
      if (!name.EndsWith(".dll")) {
        name += ".dll";
      }
      return Assembly.LoadFrom(name);
    } catch (Exception e) {
      return Result.Failure<Assembly>($"{name}: {e.Message}\n{e.StackTrace}");
    }
  }
}
