using Chronicle.Core.Model.Configuration.Raw;
using CSharpFunctionalExtensions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Chronicle.ConfigResolver;

/// <summary>
/// YAML-based configuration parser.
/// </summary>
internal class YamlConfigParser : IConfigParser {
  private IDeserializer _deserializer = new DeserializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .Build();

  /// <summary>
  /// Parse the configuration from a YAML string.
  /// </summary>
  public Result<RawConfiguration> ParseConfiguration(string data) {
    try {
      return _deserializer.Deserialize<RawConfiguration>(data);
    } catch (Exception e) {
      return Result.Failure<RawConfiguration>(e.Message);
    }
  }
}
