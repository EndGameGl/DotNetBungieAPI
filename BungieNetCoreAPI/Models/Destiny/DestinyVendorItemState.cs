using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyVendorItemState
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
        SeasonalRewardExpiration = 16384
    }
}
