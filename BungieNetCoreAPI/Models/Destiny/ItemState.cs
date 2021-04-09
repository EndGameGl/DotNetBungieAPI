using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ItemState
    {
        None = 0,
        Locked = 1,
        Tracked = 2,
        Masterwork = 4
    }
}
