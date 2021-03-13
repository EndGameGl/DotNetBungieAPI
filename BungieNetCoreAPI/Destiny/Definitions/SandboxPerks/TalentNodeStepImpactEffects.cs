using System;

namespace NetBungieApi.Destiny.Definitions.SandboxPerks
{
    [Flags]
    public enum TalentNodeStepImpactEffects
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
