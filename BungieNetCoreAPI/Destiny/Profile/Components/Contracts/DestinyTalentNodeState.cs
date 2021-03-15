namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public enum DestinyTalentNodeState
    {
        Invalid = 0,
        CanUpgrade = 1,
        NoPoints = 2,
        NoPrerequisites = 3,
        NoSteps = 4,
        NoUnlock = 5,
        NoMaterial = 6,
        NoGridLevel = 7,
        SwappingLocked = 8,
        MustSwap = 9,
        Complete = 10,
        Unknown = 11,
        CreationOnly = 12,
        Hidden = 13
    }
}
