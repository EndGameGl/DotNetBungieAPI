using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    [DestinyDefinition("DestinyMilestoneDefinition")]
    public class DestinyMilestoneDefinition : DestinyDefinition
    {
        public List<MilestoneActivities> Activities { get; }
        public int DefaultOrder { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool ExplorePrioritizesActivityImage { get; }
        public string FriendlyName { get; }
        public bool HasPredictableDates { get; }
        public string Image { get; }
        public bool IsInGameMilestone { get; }
        public MilestoneType MilestoneType { get; }
        public Dictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, MilestoneQuest> Quests { get; }
        public bool Recruitable { get; }
        public Dictionary<uint, MilestoneReward> Rewards { get; }
        public bool ShowInExplorer { get; }
        public bool ShowInMilestones { get; }
        public List<MilestoneVendor> Vendors { get; }
        public string VendorsDisplayTitle { get; }

        [JsonConstructor]
        private DestinyMilestoneDefinition(int defaultOrder, DestinyDefinitionDisplayProperties displayProperties, bool explorePrioritizesActivityImage,
            bool hasPredictableDates, bool isInGameMilestone, MilestoneType milestoneType, Dictionary<uint, MilestoneQuest> quests, bool recruitable,
            bool showInExplorer, bool showInMilestones, string friendlyName, string image, List<MilestoneActivities> activities, Dictionary<uint, MilestoneReward> rewards,
            List<MilestoneVendor> vendors, string vendorsDisplayTitle,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DefaultOrder = defaultOrder;
            DisplayProperties = displayProperties;
            ExplorePrioritizesActivityImage = explorePrioritizesActivityImage;
            HasPredictableDates = hasPredictableDates;
            IsInGameMilestone = isInGameMilestone;
            MilestoneType = milestoneType;
            Quests = new Dictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, MilestoneQuest>();
            if (quests != null)
            {
                foreach (var quest in quests)
                {
                    Quests.Add(new DefinitionHashPointer<DestinyInventoryItemDefinition>(quest.Key, "DestinyInventoryItemDefinition"), quest.Value);
                }
            }
            Recruitable = recruitable;
            ShowInExplorer = showInExplorer;
            ShowInMilestones = showInMilestones;
            FriendlyName = friendlyName;
            Image = image;
            Activities = activities;
            Rewards = rewards;
            Vendors = vendors;
            VendorsDisplayTitle = vendorsDisplayTitle;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
