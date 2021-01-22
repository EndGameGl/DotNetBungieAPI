using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SocketCategories
{
    [DestinyDefinition(name: "DestinySocketCategoryDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinySocketCategoryDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public SocketCategoryStyle CategoryStyle { get; }
        public uint UiCategoryStyle { get; }

        [JsonConstructor]
        private DestinySocketCategoryDefinition(DestinyDefinitionDisplayProperties displayProperties, SocketCategoryStyle categoryStyle, uint uiCategoryStyle,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            CategoryStyle = categoryStyle;
            UiCategoryStyle = uiCategoryStyle;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
