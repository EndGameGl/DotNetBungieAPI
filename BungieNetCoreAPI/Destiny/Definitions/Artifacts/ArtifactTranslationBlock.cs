using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Artifacts
{
    /// <summary>
    /// This Block defines the rendering data associated with the item, if any.
    /// </summary>
    public class ArtifactTranslationBlock : IDeepEquatable<ArtifactTranslationBlock>
    {
        public ReadOnlyCollection<ArtifactTranslationBlockArrangementEntry> Arrangements { get; }
        public ReadOnlyCollection<ArtifactTranslationBlockDyeEntry> CustomDyes { get; }
        public ReadOnlyCollection<ArtifactTranslationBlockDyeEntry> DefaultDyes { get; }
        public ReadOnlyCollection<ArtifactTranslationBlockDyeEntry> LockedDyes { get; }
        public bool HasGeometry { get; }
        public uint WeaponPatternHash { get; }
        public string WeaponPatternIdentifier { get; }

        [JsonConstructor]
        internal ArtifactTranslationBlock(ArtifactTranslationBlockArrangementEntry[] arrangements, ArtifactTranslationBlockDyeEntry[] customDyes, string weaponPatternIdentifier,
            ArtifactTranslationBlockDyeEntry[] defaultDyes, ArtifactTranslationBlockDyeEntry[] lockedDyes, bool hasGeometry, uint weaponPatternHash)
        {
            Arrangements = arrangements.AsReadOnlyOrEmpty();
            CustomDyes = customDyes.AsReadOnlyOrEmpty();
            DefaultDyes = defaultDyes.AsReadOnlyOrEmpty();
            LockedDyes = lockedDyes.AsReadOnlyOrEmpty();
            HasGeometry = hasGeometry;
            WeaponPatternHash = weaponPatternHash;
            WeaponPatternIdentifier = weaponPatternIdentifier;
        }

        public bool DeepEquals(ArtifactTranslationBlock other)
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
