using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions
{
    public sealed record DestinyItemTranslationBlockDefinition : IDeepEquatable<DestinyItemTranslationBlockDefinition>
    {
        [JsonPropertyName("weaponPatternIdentifier")]
        public string WeaponPatternIdentifier { get; init; }

        [JsonPropertyName("weaponPatternHash")]
        public uint WeaponPatternHash { get; init; }

        [JsonPropertyName("defaultDyes")]
        public ReadOnlyCollection<DyeReference> DefaultDyes { get; init; } = Defaults.EmptyReadOnlyCollection<DyeReference>();

        [JsonPropertyName("lockedDyes")]
        public ReadOnlyCollection<DyeReference> LockedDyes { get; init; } = Defaults.EmptyReadOnlyCollection<DyeReference>();

        [JsonPropertyName("customDyes")]
        public ReadOnlyCollection<DyeReference> CustomDyes { get; init; } = Defaults.EmptyReadOnlyCollection<DyeReference>();

        [JsonPropertyName("arrangements")]
        public ReadOnlyCollection<DestinyGearArtArrangementReference> Arrangements { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyGearArtArrangementReference>();

        [JsonPropertyName("hasGeometry")]
        public bool HasGeometry { get; init; }

        public bool DeepEquals(DestinyItemTranslationBlockDefinition other)
        {
            return other != null &&
                   Arrangements.DeepEqualsReadOnlyCollections(other.Arrangements) &&
                   CustomDyes.DeepEqualsReadOnlyCollections(other.CustomDyes) &&
                   DefaultDyes.DeepEqualsReadOnlyCollections(other.DefaultDyes) &&
                   LockedDyes.DeepEqualsReadOnlyCollections(other.LockedDyes) &&
                   HasGeometry == other.HasGeometry &&
                   WeaponPatternHash == other.WeaponPatternHash &&
                   WeaponPatternIdentifier == other.WeaponPatternIdentifier;
        }
    }
}
