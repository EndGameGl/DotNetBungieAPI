using NetBungieAPI.Models.Destiny.Definitions.Artifacts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyArtifactCharacterScoped
    {
        public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; init; }
        public int PointsUsed { get; init; }
        public int ResetCount { get; init; }
        public ReadOnlyCollection<DestinyArtifactTier> Tiers { get; init; }

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
