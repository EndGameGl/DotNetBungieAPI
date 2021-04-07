﻿using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupMembership : GroupMembershipBase
    {
        [JsonPropertyName("member")]
        public GroupMember Member { get; init; }
    }
}
