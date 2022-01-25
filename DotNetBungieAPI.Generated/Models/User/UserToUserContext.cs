namespace DotNetBungieAPI.Generated.Models.User;

public class UserToUserContext
{
    [JsonPropertyName("isFollowing")]
    public bool IsFollowing { get; set; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse IgnoreStatus { get; set; }

    [JsonPropertyName("globalIgnoreEndDate")]
    public DateTime? GlobalIgnoreEndDate { get; set; }
}
