using NetBungieApi.Destiny.Definitions.Artifacts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyArtifactCharacterScoped
    {
        public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; }
        public int PointsUsed { get; }
        public int ResetCount { get; }
        public ReadOnlyCollection<DestinyArtifactTier> Tiers { get; }

        [JsonConstructor]
        internal DestinyArtifactCharacterScoped(uint artifactHash, int pointsUsed, int resetCount, DestinyArtifactTier[] tiers)
        {
            Artifact = new DefinitionHashPointer<DestinyArtifactDefinition>(artifactHash, DefinitionsEnum.DestinyArtifactDefinition);
            PointsUsed = pointsUsed;
            ResetCount = resetCount;
            Tiers = tiers.AsReadOnlyOrEmpty();
        }
    }
}
