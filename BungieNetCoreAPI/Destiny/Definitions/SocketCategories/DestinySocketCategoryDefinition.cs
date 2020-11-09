﻿using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SocketCategories
{
    public class DestinySocketCategoryDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public int CategoryStyle { get; }
        public uint UiCategoryStyle { get; }

        [JsonConstructor]
        private DestinySocketCategoryDefinition(DestinyDefinitionDisplayProperties displayProperties, int categoryStyle, uint uiCategoryStyle,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            CategoryStyle = categoryStyle;
            UiCategoryStyle = UiCategoryStyle;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
