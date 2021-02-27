using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
            DestinyProfileComponent<Dictionary<long, ComponentDestinyItemRender>> renderData)
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

            Components = new ReadOnlyDictionary<DestinyComponentType, IProfileComponent>(components);
        }

        public bool TryGetComponent<T>(DestinyComponentType type, out T component)
        {
            component = default;
            if (Components.TryGetValue(type, out var foundComponent))
            {
                component = ((DestinyProfileComponent<T>)foundComponent).Data;
                return true;
            }
            else
                return false;
        }
    }
}
