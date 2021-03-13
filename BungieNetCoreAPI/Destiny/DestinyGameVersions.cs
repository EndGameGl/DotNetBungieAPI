using System;

namespace NetBungieApi.Destiny
{
    [Flags]
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
