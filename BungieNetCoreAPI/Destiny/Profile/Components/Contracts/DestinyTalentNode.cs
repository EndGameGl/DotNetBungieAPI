using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyTalentNode
    {
        public int NodeIndex { get; init; }
        public uint NodeHash { get; init; }
        public DestinyTalentNodeState State { get; init; }
        public bool IsActivated { get; init; }
        public int StepIndex { get; init; }
        public ReadOnlyCollection<DestinyMaterialRequirement> MaterialsToUpgrade { get; init; }
        public int ActivationGridLevel { get; init; }
        public float ProgressPercent { get; init; }
        public bool IsHidden { get; init; }
        public DestinyTalentNodeStatBlock NodeStatsBlock { get; init; }

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
