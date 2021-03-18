using NetBungieAPI.User;
using Newtonsoft.Json;

namespace NetBungieAPI.Forum
{
    public class TagResponse
    {
        public string TagText { get; }
        public IgnoreResponse IgnoreStatus { get; }

        [JsonConstructor]
        internal TagResponse(string tagText, IgnoreResponse ignoreStatus)
        {
            TagText = tagText;
            IgnoreStatus = ignoreStatus;
        }
    }
}
