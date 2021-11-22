namespace DotNetBungieAPI.Models.GroupsV2
{
    public sealed record GroupMember : GroupUserBase
    {
        [JsonPropertyName("memberType")] public RuntimeGroupMemberType MemberType { get; init; }

        [JsonPropertyName("isOnline")] public bool IsOnline { get; init; }

        [JsonPropertyName("lastOnlineStatusChange")]
        public long LastOnlineStatusChange { get; init; }
    }
}