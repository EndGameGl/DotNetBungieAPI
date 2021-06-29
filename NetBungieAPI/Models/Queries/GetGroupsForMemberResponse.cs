﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.Queries
{
    public sealed record GetGroupsForMemberResponse : SearchResultBase
    {
        [JsonPropertyName("areAllMembershipsInactive")]
        public ReadOnlyDictionary<long, bool> AreAllMembershipsInactive { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, bool>();

        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMembership> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<GroupMembership>();
    }
}