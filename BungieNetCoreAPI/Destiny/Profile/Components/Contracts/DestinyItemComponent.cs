using NetBungieAPI.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Metrics;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemComponent
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public long? ItemInstanceId { get; init; }
        public int Quantity { get; init; }
        public ItemBindStatus BindStatus { get; init; }
        public BucketItemLocation Location { get; init; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> Bucket { get; init; }
        public TransferStatuses TransferStatus { get; init; }
        public bool IsLockable { get; init; }
        public ItemState State { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; init; }
        public DateTime? ExpirationDate { get; init; }
        public bool IsWrapper { get; init; }
        public ReadOnlyCollection<int> TooltipNotificationIndexes { get; init; }
        public DefinitionHashPointer<DestinyMetricDefinition> Metric { get; init; }
        public DestinyObjectiveProgress MetricObjective { get; init; }
        public int? VersionNumber { get; init; }

        [JsonConstructor]
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
