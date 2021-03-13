using System;

namespace NetBungieApi.Destiny.Definitions.SandboxPerks
{
    [Flags]
    public enum TalentNodeStepLightAbilities
    {
        None = 0,
        Grenades = 1,
        Melee = 2,
        MovementModes = 4,
        Orbs = 8,
        SuperEnergy = 16,
        SuperMods = 32,
        All = 63
    }
}
