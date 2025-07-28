namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

public class DestinySocketTypeScalarMaterialRequirementEntry
{
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("currencyItemHash")]
    public uint CurrencyItemHash { get; set; }

    [JsonPropertyName("scalarValue")]
    public int ScalarValue { get; set; }
}
