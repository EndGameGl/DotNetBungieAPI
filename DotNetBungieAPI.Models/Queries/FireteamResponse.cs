using DotNetBungieAPI.Models.Fireteam;

namespace DotNetBungieAPI.Models.Queries;

public sealed record FireteamResponse
{
    [JsonPropertyName("Summary")]
    public FireteamSummary Summary { get; init; }

    [JsonPropertyName("Members")]
    public ReadOnlyCollection<FireteamMember> Members { get; init; } =
        ReadOnlyCollection<FireteamMember>.Empty;

    [JsonPropertyName("Alternates")]
    public ReadOnlyCollection<FireteamMember> Alternates { get; init; } =
        ReadOnlyCollection<FireteamMember>.Empty;
}
