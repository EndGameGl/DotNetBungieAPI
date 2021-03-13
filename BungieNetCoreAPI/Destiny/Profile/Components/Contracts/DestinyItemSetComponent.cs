using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyItemSetComponent
    {
        private DestinyProfileComponent<Dictionary<long, DestinyItemInstanceComponent>> _instances;
        private DestinyProfileComponent<Dictionary<long, DestinyItemObjectivesComponent>> _objectives;
        private DestinyProfileComponent<Dictionary<long, DestinyItemPerksComponent>> _perks;
        private DestinyProfileComponent<Dictionary<long, DestinyItemRenderComponent>> _renderData;
        private DestinyProfileComponent<Dictionary<long, DestinyItemStatsComponent>> _stats;
        private DestinyProfileComponent<Dictionary<long, DestinyItemSocketsComponent>> _sockets;
        private DestinyProfileComponent<Dictionary<long, DestinyItemTalentGridComponent>> _talentGrids;
        private DestinyProfileComponent<Dictionary<uint, DestinyItemPlugComponent>> _plugStates;
        private DestinyProfileComponent<Dictionary<long, DestinyItemPlugObjectivesComponent>> _plugObjectives;
        private DestinyProfileComponent<Dictionary<long, DestinyItemReusablePlugsComponent>> _reusablePlugs;

        [JsonConstructor]
        internal DestinyItemSetComponent(
            DestinyProfileComponent<Dictionary<long, DestinyItemInstanceComponent>> instances,
            DestinyProfileComponent<Dictionary<long, DestinyItemObjectivesComponent>> objectives,
            DestinyProfileComponent<Dictionary<long, DestinyItemPerksComponent>> perks,
            DestinyProfileComponent<Dictionary<long, DestinyItemRenderComponent>> renderData,
            DestinyProfileComponent<Dictionary<long, DestinyItemStatsComponent>> stats,
            DestinyProfileComponent<Dictionary<long, DestinyItemSocketsComponent>> sockets,
            DestinyProfileComponent<Dictionary<long, DestinyItemTalentGridComponent>> talentGrids,
            DestinyProfileComponent<Dictionary<uint, DestinyItemPlugComponent>> plugStates,
            DestinyProfileComponent<Dictionary<long, DestinyItemPlugObjectivesComponent>> plugObjectives,
            DestinyProfileComponent<Dictionary<long, DestinyItemReusablePlugsComponent>> reusablePlugs)
        {
            _instances = instances;
            _objectives = objectives;
            _perks = perks;
            _renderData = renderData;
            _stats = stats;
            _sockets = sockets;
            _talentGrids = talentGrids;
            _plugStates = plugStates;
            _plugObjectives = plugObjectives;
            _reusablePlugs = reusablePlugs;
        }

        public bool TryGetInstances(out DestinyProfileComponent<Dictionary<long, DestinyItemInstanceComponent>> data)
        {
            data = _instances;
            return data != null;
        }
        public bool TryGetObjectives(out DestinyProfileComponent<Dictionary<long, DestinyItemObjectivesComponent>> data)
        {
            data = _objectives;
            return data != null;
        }
        public bool TryGetPerks(out DestinyProfileComponent<Dictionary<long, DestinyItemPerksComponent>> data)
        {
            data = _perks;
            return data != null;
        }
        public bool TryGetRenderData(out DestinyProfileComponent<Dictionary<long, DestinyItemRenderComponent>> data)
        {
            data = _renderData;
            return data != null;
        }
        public bool TryGetStats(out DestinyProfileComponent<Dictionary<long, DestinyItemStatsComponent>> data)
        {
            data = _stats;
            return data != null;
        }
        public bool TryGetSockets(out DestinyProfileComponent<Dictionary<long, DestinyItemSocketsComponent>> data)
        {
            data = _sockets;
            return data != null;
        }
        public bool TryGetTalentGrids(out DestinyProfileComponent<Dictionary<long, DestinyItemTalentGridComponent>> data)
        {
            data = _talentGrids;
            return data != null;
        }
        public bool TryGetPlugStates(out DestinyProfileComponent<Dictionary<uint, DestinyItemPlugComponent>> data)
        {
            data = _plugStates;
            return data != null;
        }
        public bool TryGetPlugObjectives(out DestinyProfileComponent<Dictionary<long, DestinyItemPlugObjectivesComponent>> data)
        {
            data = _plugObjectives;
            return data != null;
        }
        public bool TryGetReusablePlugs(out DestinyProfileComponent<Dictionary<long, DestinyItemReusablePlugsComponent>> data)
        {
            data = _reusablePlugs;
            return data != null;
        }
    }
}
