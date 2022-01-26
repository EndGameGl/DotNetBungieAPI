namespace DotNetBungieAPI.Generated.Models.User;

public class UserToUserContext : IDeepEquatable<UserToUserContext>
{
    [JsonPropertyName("isFollowing")]
    public bool IsFollowing { get; set; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse IgnoreStatus { get; set; }

    [JsonPropertyName("globalIgnoreEndDate")]
    public DateTime? GlobalIgnoreEndDate { get; set; }

    public bool DeepEquals(UserToUserContext? other)
    {
        return other is not null &&
               IsFollowing == other.IsFollowing &&
               (IgnoreStatus is not null ? IgnoreStatus.DeepEquals(other.IgnoreStatus) : other.IgnoreStatus is null) &&
               GlobalIgnoreEndDate == other.GlobalIgnoreEndDate;
    }
}