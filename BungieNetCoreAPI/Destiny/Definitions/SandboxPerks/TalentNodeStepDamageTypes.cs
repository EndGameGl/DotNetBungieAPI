using System;

namespace NetBungieAPI.Destiny.Definitions.SandboxPerks
{
    [Flags]
    public enum TalentNodeStepDamageTypes
    {
        None = 0,
        Kinetic = 1,
        Arc = 2,
        Solar = 4,
        Void = 8,
        All = 15
    }
}
