using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorInteractionReply : IDeepEquatable<VendorInteractionReply>
    {
        public VendorInteractionRewardSelection ItemRewardsSelection { get; init; }
        public string Reply { get; init; }
        public VendorReplyType ReplyType { get; init; }
        public uint RewardSiteHash { get; init; }

        [JsonConstructor]
        internal VendorInteractionReply(VendorInteractionRewardSelection itemRewardsSelection, string reply, VendorReplyType replyType, uint rewardSiteHash)
        {
            ItemRewardsSelection = itemRewardsSelection;
            Reply = reply;
            ReplyType = replyType;
            RewardSiteHash = rewardSiteHash;
        }

        public bool DeepEquals(VendorInteractionReply other)
        {
            return other != null &&
                   ItemRewardsSelection == other.ItemRewardsSelection &&
                   Reply == other.Reply &&
                   ReplyType == other.ReplyType &&
                   RewardSiteHash == other.RewardSiteHash;
        }
    }
}
