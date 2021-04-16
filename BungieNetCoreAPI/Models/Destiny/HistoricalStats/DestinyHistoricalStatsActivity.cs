using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsActivity
    {
        [JsonPropertyName("referenceId")]
        public DefinitionHashPointer<DestinyActivityDefinition> ActivityReference { get; init; }
        [JsonPropertyName("directorActivityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> DirectorActivity { get; init; }
        [JsonPropertyName("instanceId")]
        public long InstanceId { get; init; }
        [JsonPropertyName("mode")]
        public DestinyActivityModeType Mode { get; init; }
        [JsonPropertyName("modes")]
        public ReadOnlyCollection<DestinyActivityModeType> Modes { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyActivityModeType>();
        [JsonPropertyName("isPrivate")]
        public bool IsPrivate { get; init; }
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; init; }
    }
}