using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Collectibles
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyCollectibleDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyCollectibleDefinition : IDestinyDefinition
    {
        public CollectibleAcquisitionInfo AcquisitionInfo { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public List<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; }
        public int PresentationNodeType { get; }
        public int Scope { get; }
        public uint SourceHash { get; }
        public string SourceString { get; }
        public CollectibleStateInfo StateInfo { get; }
        public List<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public List<string> TraitIds { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyCollectibleDefinition(CollectibleAcquisitionInfo acquisitionInfo, DestinyDefinitionDisplayProperties displayProperties, uint itemHash, List<uint> parentNodeHashes,
            int presentationNodeType, int scope, uint sourceHash, string sourceString, CollectibleStateInfo stateInfo, List<uint> traitHashes, List<string> traitIds,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            AcquisitionInfo = acquisitionInfo;
            DisplayProperties = displayProperties;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            if (parentNodeHashes == null)
                ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
            else
            {
                ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
                foreach (var parentNodeHash in parentNodeHashes)
                {
                    ParentNodes.Add(new DefinitionHashPointer<DestinyPresentationNodeDefinition>(parentNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition));
                }
            }
            PresentationNodeType = presentationNodeType;
            Scope = scope;
            SourceHash = sourceHash;
            SourceString = sourceString;
            StateInfo = stateInfo;
            if (traitHashes == null)
                Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
            else
            {
                Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
                foreach (var traitHash in traitHashes)
                {
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, DefinitionsEnum.DestinyTraitDefinition));
                }
            }
            if (traitIds == null)
                TraitIds = new List<string>();
            else
                TraitIds = traitIds;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
