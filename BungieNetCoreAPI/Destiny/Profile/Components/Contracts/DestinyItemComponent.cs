using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.Metrics;
using System;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemComponent
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public long? ItemInstanceId { get; }
        public int Quantity { get; }
        public ItemBindStatus BindStatus { get; }
        public BucketItemLocation Location { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> Bucket { get; }
        public TransferStatuses TransferStatus { get; }
        public bool IsLockable { get; }
        public ItemState State { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; }
        public DateTime? ExpirationDate { get; }
        public bool IsWrapper { get; }
        public ReadOnlyCollection<int> TooltipNotificationIndexes { get; }
        public DefinitionHashPointer<DestinyMetricDefinition> Metric { get; }
        public DestinyObjectiveProgress MetricObjective { get; }
        public int? VersionNumber { get; }
        internal DestinyItemComponent(uint itemHash, long? itemInstanceId, int quantity, ItemBindStatus bindStatus, BucketItemLocation location, uint bucketHash,
            TransferStatuses transferStatus, bool lockable, ItemState state, uint? overrideStyleItemHash, DateTime? expirationDate, bool isWrapper,
            int[] tooltipNotificationIndexes, uint? metricHash, DestinyObjectiveProgress metricObjective, int? versionNumber)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            ItemInstanceId = itemInstanceId;
            Quantity = quantity;
            BindStatus = bindStatus;
            Location = location;
            Bucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(bucketHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
            TransferStatus = transferStatus;
            IsLockable = lockable;
            State = state;
            OverrideStyleItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(overrideStyleItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            ExpirationDate = expirationDate;
            IsWrapper = isWrapper;
            TooltipNotificationIndexes = tooltipNotificationIndexes.AsReadOnlyOrEmpty();
            Metric = new DefinitionHashPointer<DestinyMetricDefinition>(metricHash, DefinitionsEnum.DestinyMetricDefinition);
            MetricObjective = metricObjective;
            VersionNumber = versionNumber;
        }
    }
}
