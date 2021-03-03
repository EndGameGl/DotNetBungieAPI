using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemSet
    {
        public ReadOnlyDictionary<DestinyComponentType, IProfileComponent> Components { get; }

        [JsonConstructor]
        internal ComponentDestinyItemSet(
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemInstance>> instances,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemObjectives>> objectives,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemPerks>> perks,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemRender>> renderData,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemStats>> stats,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemSockets>> sockets,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemTalentGrid>> talentGrids,
            DestinyProfileComponent<Dictionary<uint, ComponentDestinyItemPlug>> plugStates,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemPlugObjectives>> plugObjectives,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemReusablePlugs>> reusablePlugs)
        {
            var components = new Dictionary<DestinyComponentType, IProfileComponent>();

            if (instances != null)
                components.Add(DestinyComponentType.ItemInstances, instances);
            if (objectives != null)
                components.Add(DestinyComponentType.ItemObjectives, objectives);
            if (perks != null)
                components.Add(DestinyComponentType.ItemPerks, perks);
            if (renderData != null)
                components.Add(DestinyComponentType.ItemRenderData, renderData);
            if (stats != null)
                components.Add(DestinyComponentType.ItemStats, stats);
            if (sockets != null)
                components.Add(DestinyComponentType.ItemSockets, sockets);
            if (talentGrids != null)
                components.Add(DestinyComponentType.ItemTalentGrids, talentGrids);
            if (plugStates != null)
                components.Add(DestinyComponentType.ItemPlugStates, plugStates);
            if (plugObjectives != null)
                components.Add(DestinyComponentType.ItemPlugObjectives, plugObjectives);
            if (reusablePlugs != null)
                components.Add(DestinyComponentType.ItemReusablePlugs, reusablePlugs);

            Components = new ReadOnlyDictionary<DestinyComponentType, IProfileComponent>(components);
        }
    }
}
