using Chronicle.Core.Model.Configuration;
using Chronicle.Core.Model.Configuration.Raw;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace Chronicle.ConfigResolver;

internal interface IConfigResolver {
  /// <summary>
  /// Resolve a given raw configuration.
  /// </summary>
  /// <param name="rawConfiguration">Raw configuration to resolve</param>
  /// <param name="serviceProvider">Service provider (that has plugins registered in it)</param>
  /// <returns>Resolved configuration or error</returns>
  public Result<ResolvedConfiguration> Resolve(RawConfiguration rawConfiguration, ServiceProvider serviceProvider);
}
