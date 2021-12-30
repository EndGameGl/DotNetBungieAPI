using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

public sealed class DestinySocketTypeScalarMaterialRequirementEntry
{

    [JsonPropertyName("currencyItemHash")]
    public uint CurrencyItemHash { get; init; }

    [JsonPropertyName("scalarValue")]
    public int ScalarValue { get; init; }
}
