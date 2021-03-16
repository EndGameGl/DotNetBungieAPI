using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Clients
{
    public enum ClientScopes
    {
        ReadBasicUserProfile,
        ReadGroups,
        WriteGroups,
        AdminGroups,
        BnetWrite,
        MoveEquipDestinyItems,
        ReadDestinyInventoryAndVault,
        ReadUserData,
        EditUserData,
        ReadDestinyVendorsAndAdvisors,
        ReadAndApplyTokens,
        AdvancedWriteActions,
        PartnerOfferGrant
    }
}
