using NetBungieAPI.Models.Destiny.Definitions.Artifacts;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyArtifactProfileScoped
    {
        public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; init; }
        public DestinyProgression PointProgression { get; init; }
        public int PointsAcquired { get; init; }
        public DestinyProgression PowerBonusProgression { get; init; }
        public int PowerBonus { get; init; }

        [JsonConstructor]
        internal DestinyArtifactProfileScoped(uint artifactHash, DestinyProgression pointProgression, int pointsAcquired,
            DestinyProgression powerBonusProgression, int powerBonus)
        {
            Artifact = new DefinitionHashPointer<DestinyArtifactDefinition>(artifactHash, DefinitionsEnum.DestinyArtifactDefinition);
            PointProgression = pointProgression;
            PointsAcquired = pointsAcquired;
            PowerBonusProgression = powerBonusProgression;
            PowerBonus = powerBonus;
        }
    }
}
