using System;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.User;

namespace NetBungieAPI.Models.Social
{
    public sealed record BungieFriend
    {
        [JsonPropertyName("lastSeenAsMembershipId")]
        public long LastSeenAsMembershipId { get; init; }

        [JsonPropertyName("lastSeenAsBungieMembershipType")]
        public BungieMembershipType LastSeenAsBungieMembershipType { get; init; }

        [JsonPropertyName("bungieGlobalDisplayName")]
        public string BungieGlobalDisplayName { get; init; }

        [JsonPropertyName("bungieGlobalDisplayNameCode")]
        public short? BungieGlobalDisplayNameCode { get; init; }

        [JsonPropertyName("onlineStatus")] public PresenceStatus OnlineStatus { get; init; }

        [JsonPropertyName("onlineTitle")] public PresenceOnlineStateFlags OnlineTitle { get; init; }

        [JsonPropertyName("relationship")] public FriendRelationshipState Relationship { get; init; }

        [JsonPropertyName("bungieNetUser")] public GeneralUser BungieNetUser { get; init; }
    }
}