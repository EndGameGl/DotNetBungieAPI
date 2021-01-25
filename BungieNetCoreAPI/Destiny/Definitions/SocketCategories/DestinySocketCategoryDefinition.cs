using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SocketCategories
{
    [DestinyDefinition(name: "DestinySocketCategoryDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinySocketCategoryDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public SocketCategoryStyle CategoryStyle { get; }
        public uint UiCategoryStyle { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinySocketCategoryDefinition(DestinyDefinitionDisplayProperties displayProperties, SocketCategoryStyle categoryStyle, uint uiCategoryStyle,
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
    }
}
