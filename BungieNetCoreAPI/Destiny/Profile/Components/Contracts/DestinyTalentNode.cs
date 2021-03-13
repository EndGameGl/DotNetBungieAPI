using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyTalentNode
    {
        public int NodeIndex { get; }
        public uint NodeHash { get; }
        public DestinyTalentNodeState State { get; }
        public bool IsActivated { get; }
        public int StepIndex { get; }
        public ReadOnlyCollection<DestinyMaterialRequirement> MaterialsToUpgrade { get; }
        public int ActivationGridLevel { get; }
        public float ProgressPercent { get; }
        public bool IsHidden { get; }
        public DestinyTalentNodeStatBlock NodeStatsBlock { get; }

        [JsonConstructor]
        internal DestinyTalentNode(int nodeIndex, uint nodeHash, DestinyTalentNodeState state, bool isActivated, int stepIndex,
            DestinyMaterialRequirement[] materialsToUpgrade, int activationGridLevel, float progressPercent, bool hidden, DestinyTalentNodeStatBlock nodeStatsBlock)
        {
            NodeIndex = nodeIndex;
            NodeHash = nodeHash;
            State = state;
            IsActivated = isActivated;
            StepIndex = stepIndex;
            MaterialsToUpgrade = materialsToUpgrade.AsReadOnlyOrEmpty();
            ActivationGridLevel = activationGridLevel;
            ProgressPercent = progressPercent;
            IsHidden = hidden;
            NodeStatsBlock = nodeStatsBlock;
        }
    }
}
