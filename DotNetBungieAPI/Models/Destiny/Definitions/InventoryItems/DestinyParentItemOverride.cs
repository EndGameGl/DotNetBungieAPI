namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyParentItemOverride : IDeepEquatable<DestinyParentItemOverride>
    {
        [JsonPropertyName("additionalEquipRequirementsDisplayStrings")]
        public ReadOnlyCollection<string> AdditionalEquipRequirementsDisplayStrings { get; init; } =
            ReadOnlyCollections<string>.Empty;

        [JsonPropertyName("pipIcon")] public BungieNetResource PipIcon { get; init; }

        public bool DeepEquals(DestinyParentItemOverride other)
        {
            return other != null &&
                   AdditionalEquipRequirementsDisplayStrings.DeepEqualsReadOnlySimpleCollection(
                       other.AdditionalEquipRequirementsDisplayStrings) &&
                   PipIcon == other.PipIcon;
        }
    }
}