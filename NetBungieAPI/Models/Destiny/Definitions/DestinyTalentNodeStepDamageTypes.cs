using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyTalentNodeStepDamageTypes
    {
        None = 0,
        Kinetic = 1,
        Arc = 2,
        Solar = 4,
        Void = 8,
        All = 15
    }
}