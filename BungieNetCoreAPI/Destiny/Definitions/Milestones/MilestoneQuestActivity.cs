using BungieNetCoreAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    /// <summary>
    /// Milestones can have associated activities which provide additional information about the context, challenges, modifiers, state etc... related to this Milestone.
    /// <para/>
    /// Information we need to be able to return that data is defined here, along with Tier data to establish a relationship between a conceptual Activity and its difficulty levels and variants.
    /// </summary>
    public class MilestoneQuestActivity : IDeepEquatable<MilestoneQuestActivity>
    {
        public DefinitionHashPointer<DestinyActivityDefinition> ConceptualActivity { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyActivityDefinition>, MilestoneQuestActivityVariant> Variants { get; }

        [JsonConstructor]
        internal MilestoneQuestActivity(uint conceptualActivityHash, Dictionary<uint, MilestoneQuestActivityVariant> variants)
        {
            ConceptualActivity = new DefinitionHashPointer<DestinyActivityDefinition>(conceptualActivityHash, DefinitionsEnum.DestinyActivityDefinition);
            Variants = variants.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyActivityDefinition, MilestoneQuestActivityVariant>(DefinitionsEnum.DestinyActivityDefinition);
        }

        public bool DeepEquals(MilestoneQuestActivity other)
        {
            return other != null &&
                   ConceptualActivity.DeepEquals(other.ConceptualActivity) &&
                   Variants.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.Variants);
        }
    }
}
