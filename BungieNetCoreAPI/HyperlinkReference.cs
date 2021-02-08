using Newtonsoft.Json;

namespace BungieNetCoreAPI
{
    public class HyperlinkReference : IDeepEquatable<HyperlinkReference>
    {
        public string Title { get; }
        public string URL { get; }

        [JsonConstructor]
        internal HyperlinkReference(string title, string url)
        {
            Title = title;
            URL = url;
        }

        public bool DeepEquals(HyperlinkReference other)
        {
            return other != null && Title == other.Title && URL == other.URL;
        }
    }
}
