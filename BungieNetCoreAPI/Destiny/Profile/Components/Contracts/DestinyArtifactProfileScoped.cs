using BungieNetCoreAPI.Destiny.Definitions.Artifacts;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyArtifactProfileScoped
    {
        public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; }
        public DestinyProgression PointProgression { get; }
        public int PointsAcquired { get; }
        public DestinyProgression PowerBonusProgression { get; }
        public int PowerBonus { get; }

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
