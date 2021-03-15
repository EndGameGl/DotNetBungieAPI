using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneReward
    {
        public uint RewardEntryHash { get; }
        public bool Earned { get; }
        public bool Redeemed { get; }

        [JsonConstructor]
        internal DestinyMilestoneReward(uint rewardEntryHash, bool earned, bool redeemed)
        {
            RewardEntryHash = rewardEntryHash;
            Earned = earned;
            Redeemed = redeemed;
        }
    }
}
