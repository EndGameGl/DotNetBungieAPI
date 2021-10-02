using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupMemberApplication : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMemberApplication> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<GroupMemberApplication>();
    }
}