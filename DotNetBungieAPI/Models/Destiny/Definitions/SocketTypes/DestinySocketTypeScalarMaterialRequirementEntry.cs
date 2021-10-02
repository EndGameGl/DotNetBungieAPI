using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes
{
    public sealed record DestinySocketTypeScalarMaterialRequirementEntry :
        IDeepEquatable<DestinySocketTypeScalarMaterialRequirementEntry>
    {
        [JsonPropertyName("currencyItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> CurrencyItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        [JsonPropertyName("scalarValue")] public int ScalarValue { get; init; }

        public bool DeepEquals(DestinySocketTypeScalarMaterialRequirementEntry other)
        {
            return other != null &&
                   CurrencyItem.DeepEquals(other.CurrencyItem) &&
                   ScalarValue == other.ScalarValue;
        }
    }
}