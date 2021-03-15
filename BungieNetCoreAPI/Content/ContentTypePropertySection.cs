using Newtonsoft.Json;

namespace NetBungieAPI.Content
{
    public class ContentTypePropertySection
    {
        public string Name { get; }
        public string ReadableName { get; }
        public bool Collapsed { get; }

        [JsonConstructor]
        internal ContentTypePropertySection(string name, string readableName, bool collapsed)
        {
            Name = name;
            ReadableName = readableName;
            Collapsed = collapsed;
        }
    }
}
