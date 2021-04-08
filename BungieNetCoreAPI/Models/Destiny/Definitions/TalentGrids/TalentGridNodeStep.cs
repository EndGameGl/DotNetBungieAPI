using NetBungieAPI.Destiny.Definitions.DamageTypes;
using NetBungieAPI.Destiny.Definitions.SandboxPerks;
using NetBungieAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNodeStep : IDeepEquatable<TalentGridNodeStep>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public int StepIndex { get; init; }
        public uint NodeStepHash { get; init; }
        public string InteractionDescription { get; init; }
        public DamageType DamageTypeEnumValue { get; init; }
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; init; }
        public NodeActivationRequirement ActivationRequirement { get; init; }
        public bool CanActivateNextStep { get; init; }
        public int NextStepIndex { get; init; }
        public bool IsNextStepRandom { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinySandboxPerkDefinition>> Perks { get; init; }
        public int StartProgressionBarAtProgress { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyStatDefinition>> Stats { get; init; }
        public bool AffectsQuality { get; init; }
        public TalentNodeStepGroups StepGroups { get; init; }
        public bool AffectsLevel { get; init; }
        public ReadOnlyCollection<NodeSocketReplaceResponse> SocketReplacements { get; init; }
        public int TruePropertyIndex { get; init; }
        public int TrueStepIndex { get; init; }

        [JsonConstructor]
        internal TalentGridNodeStep(NodeActivationRequirement activationRequirement, bool affectsLevel, bool affectsQuality, bool canActivateNextStep,
            DamageType damageType, DestinyDisplayPropertiesDefinition displayProperties, string interactionDescription, bool isNextStepRandom, int nextStepIndex,
            uint nodeStepHash, uint[] perkHashes, int startProgressionBarAtProgress, uint[] statHashes, int stepIndex, int truePropertyIndex, int trueStepIndex,
            uint? damageTypeHash, TalentNodeStepGroups stepGroups, NodeSocketReplaceResponse[] socketReplacements)
        {
            ActivationRequirement = activationRequirement;
            AffectsLevel = affectsLevel;
            AffectsQuality = affectsQuality;
            CanActivateNextStep = canActivateNextStep;
            DamageTypeEnumValue = damageType;
            DisplayProperties = displayProperties;
            InteractionDescription = interactionDescription;
            IsNextStepRandom = isNextStepRandom;
            NextStepIndex = nextStepIndex;
            NodeStepHash = nodeStepHash;
            Perks = perkHashes.DefinitionsAsReadOnlyOrEmpty<DestinySandboxPerkDefinition>(DefinitionsEnum.DestinySandboxPerkDefinition);
            StartProgressionBarAtProgress = startProgressionBarAtProgress;
            Stats = statHashes.DefinitionsAsReadOnlyOrEmpty<DestinyStatDefinition>(DefinitionsEnum.DestinyStatDefinition);
            StepIndex = stepIndex;
            TruePropertyIndex = truePropertyIndex;
            TrueStepIndex = trueStepIndex;
            DamageType = new DefinitionHashPointer<DestinyDamageTypeDefinition>(damageTypeHash, DefinitionsEnum.DestinyDamageTypeDefinition);
            StepGroups = stepGroups;
            SocketReplacements = socketReplacements.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(TalentGridNodeStep other)
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
