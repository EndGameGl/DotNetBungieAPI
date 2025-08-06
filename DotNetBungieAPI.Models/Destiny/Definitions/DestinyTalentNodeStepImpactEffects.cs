namespace DotNetBungieAPI.Models.Destiny.Definitions;

[System.Flags]
public enum DestinyTalentNodeStepImpactEffects : int
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
