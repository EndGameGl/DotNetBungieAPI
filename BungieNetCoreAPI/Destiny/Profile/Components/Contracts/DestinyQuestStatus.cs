using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyQuestStatus
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Quest { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Step { get; }
        public ReadOnlyCollection<DestinyObjectiveProgress> StepObjectives { get; }
        public bool IsTracked { get; }
        public long ItemInstanceId { get; }
        public bool IsCompleted { get; }
        public bool IsRedeemed { get; }
        public bool Started { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }

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
