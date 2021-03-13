using NetBungieApi.Destiny;
using NetBungieApi.Destiny.Definitions.Artifacts;
using NetBungieApi.Destiny.Definitions.PresentationNodes;
using NetBungieApi.Destiny.Definitions.Progressions;
using NetBungieApi.Destiny.Definitions.Seasons;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Bungie
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
        public ReadOnlyCollection<DefinitionHashPointer<DestinyProgressionDefinition>> CurrentRankProgressions { get; }
        public string UndiscoveredCollectibleImage { get; }
        public string AmmoTypeHeavyIcon { get; }
        public string AmmoTypeSpecialIcon { get; }
        public string AmmoTypePrimaryIcon { get; }
        public DefinitionHashPointer<DestinyArtifactDefinition> CurrentSeasonalArtifact { get; }
        public DefinitionHashPointer<DestinySeasonDefinition> СurrentSeason { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> FutureSeasons { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> PastSeasons { get; }

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
            CurrentRankProgressions = currentRankProgressionHashes.DefinitionsAsReadOnlyOrEmpty<DestinyProgressionDefinition>(DefinitionsEnum.DestinyProgressionDefinition);
            UndiscoveredCollectibleImage = undiscoveredCollectibleImage;
            AmmoTypeHeavyIcon = ammoTypeHeavyIcon;
            AmmoTypeSpecialIcon = ammoTypeSpecialIcon;
            AmmoTypePrimaryIcon = ammoTypePrimaryIcon;
            CurrentSeasonalArtifact = new DefinitionHashPointer<DestinyArtifactDefinition>(currentSeasonalArtifactHash, DefinitionsEnum.DestinyArtifactDefinition);
            СurrentSeason = new DefinitionHashPointer<DestinySeasonDefinition>(currentSeasonHash, DefinitionsEnum.DestinySeasonDefinition);
            FutureSeasons = futureSeasonHashes.DefinitionsAsReadOnlyOrEmpty<DestinySeasonDefinition>(DefinitionsEnum.DestinySeasonDefinition);
            PastSeasons = pastSeasonHashes.DefinitionsAsReadOnlyOrEmpty<DestinySeasonDefinition>(DefinitionsEnum.DestinySeasonDefinition);
        }
    }
}
