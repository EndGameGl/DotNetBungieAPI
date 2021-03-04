using BungieNetCoreAPI.Destiny.Profile.Components;
using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyComponentCharacterResponse
    {
        private ReadOnlyDictionary<DestinyComponentType, IProfileComponent> Components { get; }
        internal DestinyComponentCharacterResponse(
            DestinyProfileComponent<ComponentDestinyInventory> inventory,
            DestinyProfileComponent<ComponentDestinyCharacter> character,
            DestinyProfileComponent<ComponentDestinyCharacterProgression> progressions,
            DestinyProfileComponent<ComponentDestinyCharacterRender> renderData,
            DestinyProfileComponent<ComponentDestinyCharacterActivities> activities,
            DestinyProfileComponent<ComponentDestinyInventory> equipment,
            DestinyProfileComponent<ComponentDestinyKiosks> kiosks,
            DestinyProfileComponent<ComponentDestinyPlugSets> plugSets,
            DestinyProfileComponent<ComponentDestinyPresentationNodes> presentationNodes)
        {

        }
    }
}
