using Chronicle.Core;

namespace Chronicle.CommonPlugins;
public class CommonPluginProvider : SimpleChroniclePluginProvider {
  public override IReadOnlyList<Type> Types { get; } = new List<Type>();
}
