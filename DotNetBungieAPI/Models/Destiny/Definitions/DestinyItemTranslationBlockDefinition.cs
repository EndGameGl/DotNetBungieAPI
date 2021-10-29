using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.Definitions
{
    /// <summary>
    ///     This Block defines the rendering data associated with the item, if any.
    /// </summary>
    public sealed record DestinyItemTranslationBlockDefinition : IDeepEquatable<DestinyItemTranslationBlockDefinition>
    {
        [JsonPropertyName("weaponPatternIdentifier")]
        public string WeaponPatternIdentifier { get; init; }

        [JsonPropertyName("weaponPatternHash")]
        public uint WeaponPatternHash { get; init; }

        [JsonPropertyName("defaultDyes")]
        public ReadOnlyCollection<DyeReference> DefaultDyes { get; init; } =
            ReadOnlyCollections<DyeReference>.Empty;

        [JsonPropertyName("lockedDyes")]
        public ReadOnlyCollection<DyeReference> LockedDyes { get; init; } =
            ReadOnlyCollections<DyeReference>.Empty;

        [JsonPropertyName("customDyes")]
        public ReadOnlyCollection<DyeReference> CustomDyes { get; init; } =
            ReadOnlyCollections<DyeReference>.Empty;

        [JsonPropertyName("arrangements")]
        public ReadOnlyCollection<DestinyGearArtArrangementReference> Arrangements { get; init; } =
            ReadOnlyCollections<DestinyGearArtArrangementReference>.Empty;

        [JsonPropertyName("hasGeometry")] public bool HasGeometry { get; init; }

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