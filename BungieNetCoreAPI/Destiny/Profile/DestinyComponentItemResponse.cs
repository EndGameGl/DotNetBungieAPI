using NetBungieApi.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Profile
{
    public class DestinyComponentItemResponse
    {
        private DestinyItemComponent _item;
        private DestinyItemInstanceComponent _instance;
        private DestinyItemObjectivesComponent _objectives;
        private DestinyItemPerksComponent _perks;
        private DestinyItemRenderComponent _renderData;
        private DestinyItemStatsComponent _stats;
        private DestinyItemTalentGridComponent _talentGrid;
        private DestinyItemSocketsComponent _sockets;
        private DestinyItemReusablePlugsComponent _reusablePlugs;
        private DestinyItemPlugObjectivesComponent _plugObjectives;
        public long? CharacterId { get; }

        [JsonConstructor]
        internal DestinyComponentItemResponse(
            long? characterId,
            DestinyItemComponent item,
            DestinyItemInstanceComponent instance,
            DestinyItemObjectivesComponent objectives,
            DestinyItemPerksComponent perks,
            DestinyItemRenderComponent renderData,
            DestinyItemStatsComponent stats,
            DestinyItemTalentGridComponent talentGrid,
            DestinyItemSocketsComponent sockets,
            DestinyItemReusablePlugsComponent reusablePlugs,
            DestinyItemPlugObjectivesComponent plugObjectives)
        {
            CharacterId = characterId;
            _item = item;
            _instance = instance;
            _objectives = objectives;
            _perks = perks;
            _renderData = renderData;
            _stats = stats;
            _talentGrid = talentGrid;
            _sockets = sockets;
            _reusablePlugs = reusablePlugs;
            _plugObjectives = plugObjectives;
        }

        public bool TryGetItem(out DestinyItemComponent data)
        {
            data = _item;
            return data != null;
        }
        public bool TryGetInstance(out DestinyItemInstanceComponent data)
        {
            data = _instance;
            return data != null;
        }
        public bool TryGetObjectives(out DestinyItemObjectivesComponent data)
        {
            data = _objectives;
            return data != null;
        }
        public bool TryGetPerks(out DestinyItemPerksComponent data)
        {
            data = _perks;
            return data != null;
        }
        public bool TryGetRenderData(out DestinyItemRenderComponent data)
        {
            data = _renderData;
            return data != null;
        }
        public bool TryGetStats(out DestinyItemStatsComponent data)
        {
            data = _stats;
            return data != null;
        }
        public bool TryGetTalentGrid(out DestinyItemTalentGridComponent data)
        {
            data = _talentGrid;
            return data != null;
        }
        public bool TryGetSockets(out DestinyItemSocketsComponent data)
        {
            data = _sockets;
            return data != null;
        }
        public bool TryGetReusablePlugs(out DestinyItemReusablePlugsComponent data)
        {
            data = _reusablePlugs;
            return data != null;
        }
        public bool TryGetPlugObjectives(out DestinyItemPlugObjectivesComponent data)
        {
            data = _plugObjectives;
            return data != null;
        }
    }
}
