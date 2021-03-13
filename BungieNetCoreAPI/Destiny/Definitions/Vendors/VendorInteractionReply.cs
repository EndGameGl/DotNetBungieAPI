using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInteractionReply : IDeepEquatable<VendorInteractionReply>
    {
        public VendorInteractionRewardSelection ItemRewardsSelection { get; }
        public string Reply { get; }
        public VendorReplyType ReplyType { get; }
        public uint RewardSiteHash { get; }

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
