using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.MaterialRequirementSets
{
    /// <summary>
    /// Many actions relating to items require you to expend materials: - Activating a talent node - Inserting a plug into a socket The items will refer to material requirements by a materialRequirementsHash in these cases, and this is the definition for those requirements in terms of the item required, how much of it is required and other interesting info. This is one of the rare/strange times where a single contract class is used both in definitions *and* in live data response contracts. I'm not sure yet whether I regret that
    /// </summary>
    public class MaterialRequirementSetEntry : IDeepEquatable<MaterialRequirementSetEntry>
    {
        /// <summary>
        /// The amount of the material required.
        /// </summary>
        public int Count { get; }
        /// <summary>
        /// If True, the material will be removed from the character's inventory when the action is performed.
        /// </summary>
        public bool DeleteOnAction { get; }
        /// <summary>
        /// The material required
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        /// <summary>
        /// If True, this requirement is "silent": don't bother showing it in a material requirements display. I mean, I'm not your mom: I'm not going to tell you you *can't* show it. But we won't show it in our UI.
        /// </summary>
        public bool OmitFromRequirements { get; }

        [JsonConstructor]
        internal MaterialRequirementSetEntry(int count, bool deleteOnAction, uint itemHash, bool omitFromRequirements)
        {
            Count = count;
            DeleteOnAction = deleteOnAction;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            OmitFromRequirements = omitFromRequirements;
        }

        public bool DeepEquals(MaterialRequirementSetEntry other)
        {
            return other != null &&
                   Count == other.Count &&
                   DeleteOnAction == other.DeleteOnAction &&
                   Item.DeepEquals(other.Item) &&
                   OmitFromRequirements == other.OmitFromRequirements;
        }
    }
}
