using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInteractionReply
    {
        public VendorInteractionRewardSelection ItemRewardsSelection { get; }
        public string Reply { get; }
        public VendorReplyType ReplyType { get; }
        public uint RewardSiteHash { get; }

        [JsonConstructor]
        private VendorInteractionReply(VendorInteractionRewardSelection itemRewardsSelection, string reply, VendorReplyType replyType, uint rewardSiteHash)
        {
            ItemRewardsSelection = itemRewardsSelection;
            Reply = reply;
            ReplyType = replyType;
            RewardSiteHash = rewardSiteHash;
        }
    }
}
