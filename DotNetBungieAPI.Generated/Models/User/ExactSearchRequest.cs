namespace DotNetBungieAPI.Generated.Models.User;

public class ExactSearchRequest : IDeepEquatable<ExactSearchRequest>
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("displayNameCode")]
    public short DisplayNameCode { get; set; }

    public bool DeepEquals(ExactSearchRequest? other)
    {
        return other is not null &&
               DisplayName == other.DisplayName &&
               DisplayNameCode == other.DisplayNameCode;
    }
}