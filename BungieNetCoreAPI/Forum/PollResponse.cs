using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Forum
{
    public class PollResponse
    {
        public long TopicId { get; }
        public ReadOnlyCollection<PollResult> Results { get; }
        public int TotalVotes { get; }

        [JsonConstructor]
        internal PollResponse(long topicId, PollResult[] results, int totalVotes)
        {
            TopicId = topicId;
            Results = results.AsReadOnlyOrEmpty();
            TotalVotes = totalVotes;
        }
    }
}
