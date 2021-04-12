using NetBungieAPI.Models.Destiny.Definitions.TalentGrids;
using NetBungieAPI.Models.Destiny.Progressions;
using NetBungieAPI.Models.Destiny.TalentNodes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemTalentGridComponent
    {
        [JsonPropertyName("talentGridHash")]
        public DefinitionHashPointer<DestinyTalentGridDefinition> TalentGrid { get; init; } = DefinitionHashPointer<DestinyTalentGridDefinition>.Empty;
        [JsonPropertyName("nodes")]
        public ReadOnlyCollection<DestinyTalentNode> Nodes { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyTalentNode>();
        [JsonPropertyName("isGridComplete")]
        public bool IsGridComplete { get; init; }
        [JsonPropertyName("gridProgression")]
        public DestinyProgression GridProgression { get; init; }
    }
}
