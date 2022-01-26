namespace DotNetBungieAPI.Generated.Models.Destiny.Components.StringVariables;

public class DestinyStringVariablesComponent : IDeepEquatable<DestinyStringVariablesComponent>
{
    [JsonPropertyName("integerValuesByHash")]
    public Dictionary<uint, int> IntegerValuesByHash { get; set; }

    public bool DeepEquals(DestinyStringVariablesComponent? other)
    {
        return other is not null &&
               IntegerValuesByHash.DeepEqualsDictionaryNaive(other.IntegerValuesByHash);
    }
}