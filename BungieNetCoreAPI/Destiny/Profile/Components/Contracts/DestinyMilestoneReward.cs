using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneReward
    {
        public uint RewardEntryHash { get; init; }
        public bool Earned { get; init; }
        public bool Redeemed { get; init; }

        [JsonConstructor]
        internal DestinyMilestoneReward(uint rewardEntryHash, bool earned, bool redeemed)
        {
            RewardEntryHash = rewardEntryHash;
            Earned = earned;
            Redeemed = redeemed;
        }
    }
}
