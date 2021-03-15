using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions
{
    /// <summary>
    /// Represents common properties for displaying <see cref="IDestinyDefinition"/>
    /// </summary>
    public class DestinyDefinitionDisplayProperties : IDeepEquatable<DestinyDefinitionDisplayProperties>
    {
        /// <summary>
        /// Definition description
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Whether this definition has icon
        /// </summary>
        public bool HasIcon { get; }
        public string Icon { get; }
        /// <summary>
        /// Definition name
        /// </summary>
        public string Name { get; }
        public string HighResolutionIcon { get; }
        public ReadOnlyCollection<DestinyDefinitionDisplayPropertiesIconSequenceEntry> IconSequences { get; internal set; }

        [JsonConstructor]
        protected DestinyDefinitionDisplayProperties(string description, bool hasIcon, string icon, string name, string highResIcon,
            DestinyDefinitionDisplayPropertiesIconSequenceEntry[] iconSequences)
        {
            Description = description;
            HasIcon = hasIcon;
            Icon = icon;
            Name = name;
            HighResolutionIcon = highResIcon;
            IconSequences = iconSequences.AsReadOnlyOrEmpty();
        }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }

        public bool DeepEquals(DestinyDefinitionDisplayProperties other)
        {
            return other != null &&
                   Description == other.Description &&
                   HasIcon == other.HasIcon &&
                   Icon == other.Icon &&
                   Name == other.Name &&
                   HighResolutionIcon == other.HighResolutionIcon &&
                   IconSequences.DeepEqualsReadOnlyCollections(other.IconSequences);
        }
    }
}
