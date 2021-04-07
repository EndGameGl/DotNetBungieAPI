using NetBungieAPI.Models.GroupsV2;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public class GroupQuery : PagedQuery
    {
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonPropertyName("groupType")]
        public GroupType GroupType { get; private set; }

        [JsonPropertyName("creationDate")]
        public GroupDateRange CreationDate { get; private set; }

        [JsonPropertyName("sortBy")]
        public GroupSortBy SortBy { get; private set; }

        [JsonPropertyName("groupMemberCountFilter")]
        public GroupMemberCountFilter? GroupMemberCountFilter { get; private set; }

        [JsonPropertyName("localeFilter")]
        public string LocaleFilter { get; private set; }

        [JsonPropertyName("tagText")]
        public string TagText { get; private set; }
    }
}
