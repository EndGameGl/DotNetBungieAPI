using NetBungieAPI.Models.Destiny.Definitions;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.TalentNodes
{
    public sealed record DestinyTalentNode
    {
        [JsonPropertyName("nodeIndex")]
        public int NodeIndex { get; init; }
        [JsonPropertyName("nodeHash")]
        public uint NodeHash { get; init; }
        [JsonPropertyName("state")]
        public DestinyTalentNodeState State { get; init; }
        [JsonPropertyName("isActivated")]
        public bool IsActivated { get; init; }
        [JsonPropertyName("stepIndex")]
        public int StepIndex { get; init; }
        [JsonPropertyName("materialsToUpgrade")]
        public ReadOnlyCollection<DestinyMaterialRequirement> MaterialsToUpgrade { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMaterialRequirement>();
        [JsonPropertyName("activationGridLevel")]
        public int ActivationGridLevel { get; init; }
        [JsonPropertyName("progressPercent")]
        public float ProgressPercent { get; init; }
        [JsonPropertyName("hidden")]
        public bool IsHidden { get; init; }
        [JsonPropertyName("nodeStatsBlock")]
        public DestinyTalentNodeStatBlock NodeStatsBlock { get; init; }
    }
}
