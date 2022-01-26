namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public class AwaPermissionRequested : IDeepEquatable<AwaPermissionRequested>
{
    /// <summary>
    ///     Type of advanced write action.
    /// </summary>
    [JsonPropertyName("type")]
    public Destiny.Advanced.AwaType Type { get; set; }

    /// <summary>
    ///     Item instance ID the action shall be applied to. This is optional for all but a new AwaType values. Rule of thumb is to provide the item instance ID if one is available.
    /// </summary>
    [JsonPropertyName("affectedItemId")]
    public long? AffectedItemId { get; set; }

    /// <summary>
    ///     Destiny membership type of the account to modify.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    /// <summary>
    ///     Destiny character ID, if applicable, that will be affected by the action.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long? CharacterId { get; set; }

    public bool DeepEquals(AwaPermissionRequested? other)
    {
        return other is not null &&
               Type == other.Type &&
               AffectedItemId == other.AffectedItemId &&
               MembershipType == other.MembershipType &&
               CharacterId == other.CharacterId;
    }
}