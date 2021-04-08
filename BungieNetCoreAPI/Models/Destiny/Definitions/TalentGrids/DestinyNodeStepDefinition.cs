using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.DamageTypes;
using NetBungieAPI.Models.Destiny.Definitions.SandboxPerks;
using NetBungieAPI.Models.Destiny.Definitions.Stats;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    public sealed record DestinyNodeStepDefinition : IDeepEquatable<DestinyNodeStepDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("stepIndex")]
        public int StepIndex { get; init; }
        [JsonPropertyName("nodeStepHash")]
        public uint NodeStepHash { get; init; }
        [JsonPropertyName("interactionDescription")]
        public string InteractionDescription { get; init; }
        [JsonPropertyName("damageType")]
        public DamageType DamageTypeEnumValue { get; init; }
        [JsonPropertyName("damageTypeHash")]
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; init; } = DefinitionHashPointer<DestinyDamageTypeDefinition>.Empty;
        [JsonPropertyName("activationRequirement")]
        public DestinyNodeActivationRequirement ActivationRequirement { get; init; }
        [JsonPropertyName("canActivateNextStep")]
        public bool CanActivateNextStep { get; init; }
        [JsonPropertyName("nextStepIndex")]
        public int NextStepIndex { get; init; }
        [JsonPropertyName("isNextStepRandom")]
        public bool IsNextStepRandom { get; init; }
        [JsonPropertyName("perkHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinySandboxPerkDefinition>> Perks { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinySandboxPerkDefinition>>();
        [JsonPropertyName("startProgressionBarAtProgress")]
        public int StartProgressionBarAtProgress { get; init; }
        [JsonPropertyName("statHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyStatDefinition>> Stats { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyStatDefinition>>();
        [JsonPropertyName("affectsQuality")]
        public bool AffectsQuality { get; init; }
        [JsonPropertyName("stepGroups")]
        public TalentNodeStepGroups StepGroups { get; init; }
        [JsonPropertyName("affectsLevel")]
        public bool AffectsLevel { get; init; }
        [JsonPropertyName("socketReplacements")]
        public ReadOnlyCollection<DestinyNodeSocketReplaceResponse> SocketReplacements { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyNodeSocketReplaceResponse>();
        [JsonPropertyName("truePropertyIndex")]
        public int TruePropertyIndex { get; init; }
        [JsonPropertyName("trueStepIndex")]
        public int TrueStepIndex { get; init; }

        public bool DeepEquals(DestinyNodeStepDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   StepIndex == other.StepIndex &&
                   NodeStepHash == other.NodeStepHash &&
                   InteractionDescription == other.InteractionDescription &&
                   DamageTypeEnumValue == other.DamageTypeEnumValue &&
                   DamageType.DeepEquals(other.DamageType) &&
                   ActivationRequirement.DeepEquals(other.ActivationRequirement) &&
                   CanActivateNextStep == other.CanActivateNextStep &&
                   NextStepIndex == other.NextStepIndex &&
                   IsNextStepRandom == other.IsNextStepRandom &&
                   Perks.DeepEqualsReadOnlyCollections(other.Perks) &&
                   StartProgressionBarAtProgress == other.StartProgressionBarAtProgress &&
                   Stats.DeepEqualsReadOnlyCollections(other.Stats) &&
                   AffectsQuality == other.AffectsQuality &&
                   StepGroups.DeepEquals(other.StepGroups) &&
                   AffectsLevel == other.AffectsLevel &&
                   SocketReplacements.DeepEqualsReadOnlyCollections(other.SocketReplacements) &&
                   TruePropertyIndex == other.TruePropertyIndex &&
                   TrueStepIndex == other.TrueStepIndex;
        }
    }
}
