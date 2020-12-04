using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInteractionReply
    {
        public int ItemRewardsSelection { get; }
        public string Reply { get; }
        public int ReplyType { get; }
        public uint RewardSiteHash { get; }

        [JsonConstructor]
        private VendorInteractionReply(int itemRewardsSelection, string reply, int replyType, uint rewardSiteHash)
        {
            ItemRewardsSelection = itemRewardsSelection;
            Reply = reply;
            ReplyType = replyType;
            RewardSiteHash = rewardSiteHash;
        }
    }
}
