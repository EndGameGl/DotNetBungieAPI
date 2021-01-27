using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions.Artifacts;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using BungieNetCoreAPI.Destiny.Definitions.Seasons;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetDestiny2CoreSettings
    {
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> BadgesRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> MetricsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> ActiveTriumphsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> ActiveSealsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> LegacyTriumphsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> LegacySealsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> MedalsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> ExoticCatalystsRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> LoreRootNode { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition>[] CurrentRankProgressions { get; }
        public string UndiscoveredCollectibleImage { get; }
        public string AmmoTypeHeavyIcon { get; }
        public string AmmoTypeSpecialIcon { get; }
        public string AmmoTypePrimaryIcon { get; }
        public DefinitionHashPointer<DestinyArtifactDefinition> CurrentSeasonalArtifact { get; }
        public DefinitionHashPointer<DestinySeasonDefinition> СurrentSeason { get; }
        public DefinitionHashPointer<DestinySeasonDefinition>[] FutureSeasons { get; }
        public DefinitionHashPointer<DestinySeasonDefinition>[] PastSeasons { get; }
        [JsonConstructor]
        internal BungieNetDestiny2CoreSettings(uint collectionRootNode, uint badgesRootNode, uint recordsRootNode, uint medalsRootNode, uint metricsRootNode,
            uint activeTriumphsRootNodeHash, uint activeSealsRootNodeHash, uint legacyTriumphsRootNodeHash, uint legacySealsRootNodeHash, uint medalsRootNodeHash,
            uint exoticCatalystsRootNodeHash, uint loreRootNodeHash, uint[] currentRankProgressionHashes, string undiscoveredCollectibleImage, string ammoTypeHeavyIcon,
            string ammoTypeSpecialIcon, string ammoTypePrimaryIcon, uint currentSeasonalArtifactHash, uint? currentSeasonHash, uint[] futureSeasonHashes, uint[] pastSeasonHashes)
        {
            CollectionRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(collectionRootNode, DefinitionsEnum.DestinyPresentationNodeDefinition);
            BadgesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(badgesRootNode, DefinitionsEnum.DestinyPresentationNodeDefinition);
            RecordsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(recordsRootNode, DefinitionsEnum.DestinyPresentationNodeDefinition);
            SealsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(medalsRootNode, DefinitionsEnum.DestinyPresentationNodeDefinition);
            MetricsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(metricsRootNode, DefinitionsEnum.DestinyPresentationNodeDefinition);
            ActiveTriumphsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(activeTriumphsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            ActiveSealsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(activeSealsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            LegacyTriumphsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(legacyTriumphsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            LegacySealsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(legacySealsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            MedalsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(medalsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            ExoticCatalystsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(exoticCatalystsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            LoreRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(loreRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            if (currentRankProgressionHashes != null)
            {
                CurrentRankProgressions = new DefinitionHashPointer<DestinyProgressionDefinition>[currentRankProgressionHashes.Length];
                for (int i = 0; i < currentRankProgressionHashes.Length; i++)
                {
                    CurrentRankProgressions[i] = new DefinitionHashPointer<DestinyProgressionDefinition>(currentRankProgressionHashes[i], DefinitionsEnum.DestinyProgressionDefinition);
                }
            }
            UndiscoveredCollectibleImage = undiscoveredCollectibleImage;
            AmmoTypeHeavyIcon = ammoTypeHeavyIcon;
            AmmoTypeSpecialIcon = ammoTypeSpecialIcon;
            AmmoTypePrimaryIcon = ammoTypePrimaryIcon;
            CurrentSeasonalArtifact = new DefinitionHashPointer<DestinyArtifactDefinition>(currentSeasonalArtifactHash, DefinitionsEnum.DestinyArtifactDefinition);
            СurrentSeason = new DefinitionHashPointer<DestinySeasonDefinition>(currentSeasonHash, DefinitionsEnum.DestinySeasonDefinition);
            if (futureSeasonHashes != null)
            {
                FutureSeasons = new DefinitionHashPointer<DestinySeasonDefinition>[futureSeasonHashes.Length];
                for (int i = 0; i < futureSeasonHashes.Length; i++)
                {
                    FutureSeasons[i] = new DefinitionHashPointer<DestinySeasonDefinition>(futureSeasonHashes[i], DefinitionsEnum.DestinySeasonDefinition);
                }
            }
            if (pastSeasonHashes != null)
            {
                PastSeasons = new DefinitionHashPointer<DestinySeasonDefinition>[pastSeasonHashes.Length];
                for (int i = 0; i < pastSeasonHashes.Length; i++)
                {
                    PastSeasons[i] = new DefinitionHashPointer<DestinySeasonDefinition>(pastSeasonHashes[i], DefinitionsEnum.DestinySeasonDefinition);
                }
            }
        }
    }
}
