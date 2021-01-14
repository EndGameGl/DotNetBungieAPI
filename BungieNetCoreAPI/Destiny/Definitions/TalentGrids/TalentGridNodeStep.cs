using BungieNetCoreAPI.Destiny.Definitions.DamageTypes;
using BungieNetCoreAPI.Destiny.Definitions.SandboxPerks;
using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNodeStep
    {
        public TalentGridNodeStepActivationRequirement ActivationRequirement { get; }
        public bool AffectsLevel { get; }
        public bool AffectsQuality { get; }
        public bool CanActivateNextStep { get; }
        public DamageType DamageType { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string InteractionDescription { get; }
        public bool IsNextStepRandom { get; }
        public int NextStepIndex { get; }
        public uint NodeStepHash { get; }
        public List<DefinitionHashPointer<DestinySandboxPerkDefinition>> Perks { get; }
        public int StartProgressionBarAtProgress { get; }
        public List<DefinitionHashPointer<DestinyStatDefinition>> Stats { get; }
        public int StepIndex { get; }
        public int TruePropertyIndex { get; }
        public int TrueStepIndex { get; }

        [JsonConstructor]
        private TalentGridNodeStep(TalentGridNodeStepActivationRequirement activationRequirement, bool affectsLevel, bool affectsQuality, bool canActivateNextStep,
            DamageType damageType, DestinyDefinitionDisplayProperties displayProperties, string interactionDescription, bool isNextStepRandom, int nextStepIndex,
            uint nodeStepHash, List<uint> perkHashes, int startProgressionBarAtProgress, List<uint> statHashes, int stepIndex, int truePropertyIndex, int trueStepIndex)
        {
            ActivationRequirement = activationRequirement;
            AffectsLevel = affectsLevel;
            AffectsQuality = affectsQuality;
            CanActivateNextStep = canActivateNextStep;
            DamageType = damageType;
            DisplayProperties = displayProperties;
            InteractionDescription = interactionDescription;
            IsNextStepRandom = isNextStepRandom;
            NextStepIndex = nextStepIndex;
            NodeStepHash = nodeStepHash;
            Perks = new List<DefinitionHashPointer<DestinySandboxPerkDefinition>>();
            if (perkHashes != null)
            {
                foreach (var perkHash in perkHashes)
                {
                    Perks.Add(new DefinitionHashPointer<DestinySandboxPerkDefinition>(perkHash, "DestinySandboxPerkDefinition"));
                }
            }
            StartProgressionBarAtProgress = startProgressionBarAtProgress;
            Stats = new List<DefinitionHashPointer<DestinyStatDefinition>>();
            if (statHashes != null)
            {
                foreach (var statHash in statHashes)
                {
                    Stats.Add(new DefinitionHashPointer<DestinyStatDefinition>(statHash, "DestinyStatDefinition"));
                }
            }
            StepIndex = stepIndex;
            TruePropertyIndex = truePropertyIndex;
            TrueStepIndex = trueStepIndex;
        }
    }
}
