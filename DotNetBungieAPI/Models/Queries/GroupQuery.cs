using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record GroupQuery : PagedQuery
    {
        /// <summary>
        ///     Query for a usual group
        /// </summary>
        /// <param name="name"></param>
        /// <param name="creationDate"></param>
        /// <param name="sortBy"></param>
        /// <param name="groupMemberCountFilter"></param>
        /// <param name="localeFilter"></param>
        /// <param name="tagText"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="currentPage"></param>
        /// <param name="requestContinuationToken"></param>
        public GroupQuery(string name, GroupDateRange creationDate, GroupSortBy sortBy,
            GroupMemberCountFilter? groupMemberCountFilter, string localeFilter, string tagText, int itemsPerPage,
            int currentPage, string requestContinuationToken)
        {
            Name = name;
            GroupType = GroupType.General;
            CreationDate = creationDate;
            SortBy = sortBy;
            GroupMemberCountFilter = groupMemberCountFilter;
            LocaleFilter = localeFilter;
            TagText = tagText;
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
            RequestContinuationToken = requestContinuationToken;
        }

        /// <summary>
        ///     Query for a clan
        /// </summary>
        /// <param name="name"></param>
        /// <param name="creationDate"></param>
        /// <param name="sortBy"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="currentPage"></param>
        /// <param name="requestContinuationToken"></param>
        public GroupQuery(string name, GroupDateRange creationDate, GroupSortBy sortBy, int itemsPerPage,
            int currentPage, string requestContinuationToken)
        {
            Name = name;
            GroupType = GroupType.Clan;
            CreationDate = creationDate;
            SortBy = sortBy;
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
            RequestContinuationToken = requestContinuationToken;
        }

        [JsonPropertyName("name")] public string Name { get; }

        [JsonPropertyName("groupType")] public GroupType GroupType { get; }

        [JsonPropertyName("creationDate")] public GroupDateRange CreationDate { get; }

        [JsonPropertyName("sortBy")] public GroupSortBy SortBy { get; }

        [JsonPropertyName("groupMemberCountFilter")]
        public GroupMemberCountFilter? GroupMemberCountFilter { get; }

        [JsonPropertyName("localeFilter")] public string LocaleFilter { get; }

        [JsonPropertyName("tagText")] public string TagText { get; }
    }
}