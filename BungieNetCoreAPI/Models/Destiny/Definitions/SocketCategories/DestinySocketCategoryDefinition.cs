using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SocketCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinySocketCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinySocketCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinySocketCategoryDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("categoryStyle")]
        public DestinySocketCategoryStyle CategoryStyle { get; init; }
        [JsonPropertyName("uiCategoryStyle")]
        public uint UiCategoryStyle { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
        public void MapValues()
        {
            return;
        }

        public bool DeepEquals(DestinySocketCategoryDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   CategoryStyle == other.CategoryStyle &&
                   UiCategoryStyle == other.UiCategoryStyle &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
