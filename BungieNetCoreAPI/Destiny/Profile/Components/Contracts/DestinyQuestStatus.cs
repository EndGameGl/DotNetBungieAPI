using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyQuestStatus
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Quest { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Step { get; init; }
        public ReadOnlyCollection<DestinyObjectiveProgress> StepObjectives { get; init; }
        public bool IsTracked { get; init; }
        public long ItemInstanceId { get; init; }
        public bool IsCompleted { get; init; }
        public bool IsRedeemed { get; init; }
        public bool Started { get; init; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; }

        [JsonConstructor]
        internal DestinyQuestStatus(uint questHash, uint stepHash, DestinyObjectiveProgress[] stepObjectives, bool tracked, long itemInstanceId,
            bool completed, bool redeemed, bool started, uint? vendorHash)
        {
            Quest = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Step = new DefinitionHashPointer<DestinyInventoryItemDefinition>(stepHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            StepObjectives = stepObjectives.AsReadOnlyOrEmpty();
            IsTracked = tracked;
            ItemInstanceId = itemInstanceId;
            IsCompleted = completed;
            IsRedeemed = redeemed;
            Started = started;
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
        }
    }
}
