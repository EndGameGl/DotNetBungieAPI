using DotNetBungieAPI.Models.Ignores;

namespace DotNetBungieAPI.Models.User;

public sealed record UserToUserContext
{
    [JsonPropertyName("isFollowing")]
    public bool IsFollowing { get; init; }

    [JsonPropertyName("ignoreStatus")]
    public IgnoreResponse IgnoreStatus { get; init; }

    [JsonPropertyName("globalIgnoreEndDate")]
    public DateTime? GlobalIgnoreEndDate { get; init; }
}
