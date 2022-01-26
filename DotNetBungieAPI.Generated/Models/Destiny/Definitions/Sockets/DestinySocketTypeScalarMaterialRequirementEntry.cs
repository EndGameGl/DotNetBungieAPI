namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

public class DestinySocketTypeScalarMaterialRequirementEntry : IDeepEquatable<DestinySocketTypeScalarMaterialRequirementEntry>
{
    [JsonPropertyName("currencyItemHash")]
    public uint CurrencyItemHash { get; set; }

    [JsonPropertyName("scalarValue")]
    public int ScalarValue { get; set; }

    public bool DeepEquals(DestinySocketTypeScalarMaterialRequirementEntry? other)
    {
        return other is not null &&
               CurrencyItemHash == other.CurrencyItemHash &&
               ScalarValue == other.ScalarValue;
    }
}