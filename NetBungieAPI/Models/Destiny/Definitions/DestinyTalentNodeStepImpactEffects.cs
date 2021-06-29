using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyTalentNodeStepImpactEffects
    {
        None = 0,
        ArmorPiercing = 1,
        Ricochet = 2,
        Flinch = 4,
        CollateralDamage = 8,
        Disorient = 16,
        HighlightTarget = 32,
        All = 63
    }
}