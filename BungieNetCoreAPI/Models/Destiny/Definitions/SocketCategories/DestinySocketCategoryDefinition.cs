using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.SocketCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinySocketCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySocketCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinySocketCategoryDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public SocketCategoryStyle CategoryStyle { get; init; }
        public uint UiCategoryStyle { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinySocketCategoryDefinition(DestinyDisplayPropertiesDefinition displayProperties, SocketCategoryStyle categoryStyle, uint uiCategoryStyle,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            CategoryStyle = categoryStyle;
            UiCategoryStyle = uiCategoryStyle;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

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
