using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyPresentationNodeState
    {
        None = 0,
        Invisible = 1,
        Obscured = 2
    }
}
