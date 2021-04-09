using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyJoinClosedReasons
    {
        None = 0,
        InMatchmaking = 1,
        Loading = 2,
        SoloMode = 4,
        InternalReasons = 8,
        DisallowedByGameState = 16,
        Offline = 32768
    }
}
