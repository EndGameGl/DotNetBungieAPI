using NetBungieAPI.Models.Destiny.Artifacts;
using NetBungieAPI.Models.Destiny.Definitions.Checklists;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyProfileProgressionComponent
    {
        [JsonPropertyName("checklists")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>> Checklists { get; init; }
        [JsonPropertyName("seasonalArtifact")]
        public DestinyArtifactProfileScoped SeasonalArtifact { get; init; }
    }
}
