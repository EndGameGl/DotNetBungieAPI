using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Artifacts
{
    public class ArtifactTranslationBlock
    {
        public List<ArtifactTranslationBlockArrangementEntry> Arrangements { get; }
        public List<ArtifactTranslationBlockDyeEntry> CustomDyes { get; }
        public List<ArtifactTranslationBlockDyeEntry> DefaultDyes { get; }
        public List<ArtifactTranslationBlockDyeEntry> LockedDyes { get; }
        public bool HasGeometry { get; }
        public uint WeaponPatternHash { get; }

        [JsonConstructor]
        private ArtifactTranslationBlock(List<ArtifactTranslationBlockArrangementEntry> arrangements, List<ArtifactTranslationBlockDyeEntry> customDyes,
            List<ArtifactTranslationBlockDyeEntry> defaultDyes, List<ArtifactTranslationBlockDyeEntry> lockedDyes, bool hasGeometry, uint weaponPatternHash)
        {
            if (arrangements == null)
                Arrangements = new List<ArtifactTranslationBlockArrangementEntry>();
            else
                Arrangements = arrangements;
            if (customDyes == null)
                CustomDyes = new List<ArtifactTranslationBlockDyeEntry>();
            else
                CustomDyes = customDyes; 
            if (defaultDyes == null)
                DefaultDyes = new List<ArtifactTranslationBlockDyeEntry>();
            else
                DefaultDyes = defaultDyes;
            if (lockedDyes == null)
                LockedDyes = new List<ArtifactTranslationBlockDyeEntry>();
            else
                LockedDyes = lockedDyes;
            HasGeometry = hasGeometry;
            WeaponPatternHash = weaponPatternHash;

        }
    }
}
