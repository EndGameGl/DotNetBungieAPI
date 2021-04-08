using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Common
{
    /// <summary>
    /// Represents common properties for displaying <see cref="IDestinyDefinition"/>
    /// </summary>
    public record DestinyDisplayPropertiesDefinition : IDeepEquatable<DestinyDisplayPropertiesDefinition>
    {
        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("hasIcon")]
        public bool HasIcon { get; init; }

        [JsonPropertyName("icon")]
        public string Icon { get; init; }        

        [JsonPropertyName("highResIcon")]
        public string HighResolutionIcon { get; init; }

        [JsonPropertyName("iconSequences")]
        public ReadOnlyCollection<DestinyIconSequenceDefinition> IconSequences { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyIconSequenceDefinition>();

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }

        public bool DeepEquals(DestinyDisplayPropertiesDefinition other)
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
