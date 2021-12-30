using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum DestinyVendorItemState : int
{
    None = 0,
    Incomplete = 1,
    RewardAvailable = 2,
    Complete = 4,
    New = 8,
    Featured = 16,
    Ending = 32,
    OnSale = 64,
    Owned = 128,
    WideView = 256,
    NexusAttention = 512,
    SetDiscount = 1024,
    PriceDrop = 2048,
    DailyOffer = 4096,
    Charity = 8192,
    SeasonalRewardExpiration = 16384,
    BestDeal = 32768,
    Popular = 65536,
    Free = 131072
}
