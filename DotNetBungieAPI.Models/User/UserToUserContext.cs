namespace DotNetBungieAPI.Models.User;

public sealed class UserToUserContext
{
    [JsonPropertyName("isFollowing")]
    public bool IsFollowing { get; init; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse? IgnoreStatus { get; init; }

    [JsonPropertyName("globalIgnoreEndDate")]
    public DateTime? GlobalIgnoreEndDate { get; init; }
}
