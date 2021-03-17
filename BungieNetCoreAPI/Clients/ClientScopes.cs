using System;

namespace NetBungieAPI.Clients
{
    [Flags]
    public enum ClientScopes
    {
        ReadBasicUserProfile = 1,
        ReadGroups = 2,
        WriteGroups = 4,
        AdminGroups = 8,
        BnetWrite = 16,
        MoveEquipDestinyItems = 32,
        ReadDestinyInventoryAndVault = 64,
        ReadUserData = 128,
        EditUserData = 256,
        ReadDestinyVendorsAndAdvisors = 512,
        ReadAndApplyTokens = 1024,
        AdvancedWriteActions = 2048,
        PartnerOfferGrant = 4096
    }
}
