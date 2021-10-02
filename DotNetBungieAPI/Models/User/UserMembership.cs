using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.User
{
    /// <summary>
    ///     Very basic info about a user as returned by the Account server.
    /// </summary>
    public record UserMembership
    {
        /// <summary>
        ///     Type of the membership. Not necessarily the native type.
        /// </summary>
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; init; }

        /// <summary>
        ///     Membership ID as they user is known in the Accounts service
        /// </summary>
        [JsonPropertyName("membershipId")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long MembershipId { get; init; }

        /// <summary>
        ///     Display Name the player has chosen for themselves. The display name is optional when the data type is used as input
        ///     to a platform API.
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }

        /// <summary>
        /// The bungie global display name, if set.
        /// </summary>
        [JsonPropertyName("bungieGlobalDisplayName")]
        public string BungieGlobalDisplayName { get; init; }

        /// <summary>
        /// The bungie global display name code, if set.
        /// </summary>
        [JsonPropertyName("bungieGlobalDisplayNameCode")]
        public short? BungieGlobalDisplayNameCode { get; init; }
    }
}