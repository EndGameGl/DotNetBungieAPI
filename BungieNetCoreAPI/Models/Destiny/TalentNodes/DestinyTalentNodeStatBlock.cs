using NetBungieAPI.Models.Destiny.Items;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.TalentNodes
{
    public sealed record DestinyTalentNodeStatBlock
    {
        [JsonPropertyName("currentStepStats")]
        public ReadOnlyCollection<DestinyStat> CurrentStepStats { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyStat>();
        [JsonPropertyName("nextStepStats")]
        public ReadOnlyCollection<DestinyStat> NextStepStats { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyStat>();
    }
}
