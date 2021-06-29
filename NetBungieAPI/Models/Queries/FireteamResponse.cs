using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Fireteam;

namespace NetBungieAPI.Models.Queries
{
    public sealed record FireteamResponse
    {
        [JsonPropertyName("Summary")] public FireteamSummary Summary { get; init; }

        [JsonPropertyName("Members")]
        public ReadOnlyCollection<FireteamMember> Members { get; init; } =
            Defaults.EmptyReadOnlyCollection<FireteamMember>();

        [JsonPropertyName("Alternates")]
        public ReadOnlyCollection<FireteamMember> Alternates { get; init; } =
            Defaults.EmptyReadOnlyCollection<FireteamMember>();
    }
}