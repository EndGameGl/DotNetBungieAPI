using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupPotentialMembership : GroupMembershipBase
    {
        [JsonPropertyName("member")] public GroupPotentialMember Member { get; init; }
    }
}