using System;

namespace NetBungieApi.Destiny.Definitions.SandboxPerks
{
    [Flags]
    public enum TalentNodeStepGuardianAttributes
    {
        None = 0,
        Stats = 1,
        Shields = 2,
        Health = 4,
        Revive = 8,
        AimUnderFire = 16,
        Radar = 32,
        Invisibility = 64,
        Reputations = 128,
        All = 255
    }
}
