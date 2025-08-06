namespace DotNetBungieAPI.Models.Destiny.Definitions.Sockets;

public sealed class DestinySocketTypeScalarMaterialRequirementEntry
{
    [JsonPropertyName("currencyItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> CurrencyItemHash { get; init; }

    [JsonPropertyName("scalarValue")]
    public int ScalarValue { get; init; }
}
