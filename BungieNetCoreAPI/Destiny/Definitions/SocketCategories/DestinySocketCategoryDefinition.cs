using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.SocketCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinySocketCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySocketCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinySocketCategoryDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public SocketCategoryStyle CategoryStyle { get; }
        public uint UiCategoryStyle { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinySocketCategoryDefinition(DestinyDefinitionDisplayProperties displayProperties, SocketCategoryStyle categoryStyle, uint uiCategoryStyle,
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
