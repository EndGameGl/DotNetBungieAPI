using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Collectibles
{
    public class DestinyCollectibleDefinition : DestinyDefinition
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

        [JsonConstructor]
        private DestinyCollectibleDefinition(CollectibleAcquisitionInfo acquisitionInfo, DestinyDefinitionDisplayProperties displayProperties, uint itemHash, List<uint> parentNodeHashes,
            int presentationNodeType, int scope, uint sourceHash, string sourceString, CollectibleStateInfo stateInfo, List<uint> traitHashes, List<string> traitIds,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            AcquisitionInfo = acquisitionInfo;
            DisplayProperties = displayProperties;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, "DestinyInventoryItemDefinition");
            if (parentNodeHashes == null)
                ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
            else
            {
                ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
                foreach (var parentNodeHash in parentNodeHashes)
                {
                    ParentNodes.Add(new DefinitionHashPointer<DestinyPresentationNodeDefinition>(parentNodeHash, "DestinyPresentationNodeDefinition"));
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
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, "DestinyTraitDefinition"));
                }
            }
            if (traitIds == null)
                TraitIds = new List<string>();
            else
                TraitIds = traitIds;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
