using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public sealed class AwaPermissionRequested
{

    /// <summary>
    ///     Type of advanced write action.
    /// </summary>
    [JsonPropertyName("type")]
    public Destiny.Advanced.AwaType Type { get; init; }

    /// <summary>
    ///     Item instance ID the action shall be applied to. This is optional for all but a new AwaType values. Rule of thumb is to provide the item instance ID if one is available.
    /// </summary>
    [JsonPropertyName("affectedItemId")]
    public long? AffectedItemId { get; init; }

    /// <summary>
    ///     Destiny membership type of the account to modify.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    /// <summary>
    ///     Destiny character ID, if applicable, that will be affected by the action.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long? CharacterId { get; init; }
}
