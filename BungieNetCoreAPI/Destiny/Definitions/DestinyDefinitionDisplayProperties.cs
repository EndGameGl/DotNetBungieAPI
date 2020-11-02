using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions
{
    public class DestinyDefinitionDisplayProperties
    {
        public string Description { get; }
        public bool HasIcon { get; }
        public string Icon { get; }
        public string Name { get; }
        public string HighResolutionIcon { get; }
        public List<DestinyDefinitionDisplayPropertiesIconSequenceEntry> IconSequences { get; }

        [JsonConstructor]
        protected DestinyDefinitionDisplayProperties(string description, bool hasIcon, string icon, string name, string highResIcon, 
            List<DestinyDefinitionDisplayPropertiesIconSequenceEntry> iconSequences)
        {
            Description = description;
            HasIcon = hasIcon;
            Icon = icon;
            Name = name;
            HighResolutionIcon = highResIcon;
            if (iconSequences == null)
                IconSequences = new List<DestinyDefinitionDisplayPropertiesIconSequenceEntry>();
            else
                IconSequences = iconSequences;
        }
    }
}
