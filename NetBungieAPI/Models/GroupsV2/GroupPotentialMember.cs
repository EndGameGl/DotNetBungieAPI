using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupPotentialMember : GroupUserBase
    {
        [JsonPropertyName("potentialStatus")]
        public GroupPotentialMemberStatus PotentialStatus { get; init; }
    }
}
