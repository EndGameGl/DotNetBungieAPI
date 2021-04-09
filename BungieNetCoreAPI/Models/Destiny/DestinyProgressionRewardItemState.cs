using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyProgressionRewardItemState
    {
        None = 0,
        Invisible = 1,
        Earned = 2,
        Claimed = 4,
        ClaimAllowed = 8
    }
}
