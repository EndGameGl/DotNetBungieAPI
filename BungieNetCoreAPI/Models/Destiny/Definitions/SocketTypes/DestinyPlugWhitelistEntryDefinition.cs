using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SocketTypes
{
    public sealed record DestinyPlugWhitelistEntryDefinition : IDeepEquatable<DestinyPlugWhitelistEntryDefinition>
    {
        [JsonPropertyName("categoryHash")]
        public uint CategoryHash { get; init; }
        [JsonPropertyName("categoryIdentifier")]
        public string CategoryIdentifier { get; init; }
        [JsonPropertyName("reinitializationPossiblePlugHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> ReinitializationPossiblePlugs { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>>();

        public bool DeepEquals(DestinyPlugWhitelistEntryDefinition other)
        {
            return other != null &&
                   CategoryHash == other.CategoryHash &&
                   CategoryIdentifier == other.CategoryIdentifier &&
                   ReinitializationPossiblePlugs.DeepEqualsReadOnlyCollections(other.ReinitializationPossiblePlugs);
        }
    }
}
