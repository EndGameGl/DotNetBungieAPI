using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    /// <summary>
    /// A flags enumeration/bitmask indicating the versions of the game that a given user has purchased.
    /// </summary>
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyGameVersions
    {
        None = 0,
        Vanilla = 1,
        Osiris = 2,
        Warmind = 4,
        Forsaken = 8,
        YearTwoAnnualPass = 16,
        Shadowkeep = 32,
        BeyondLight = 64
    }
}