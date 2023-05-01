using Chronicle.Core.Model.Configuration.Raw;
using CSharpFunctionalExtensions;

namespace Chronicle.ConfigResolver;

internal interface IConfigParser {
  Result<RawConfiguration> ParseConfiguration(string data);
}