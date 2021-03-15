using Newtonsoft.Json;

namespace NetBungieAPI.Content
{
    public class ContentPreview
    {
        public string Name { get; }
        public string Path { get; }
        public bool ItemInSet { get; }
        public string SetTag { get; }
        public int SetNesting { get; }
        public int UseSetId { get; }

        [JsonConstructor]
        internal ContentPreview(string name, string path, bool itemInSet, string setTag, int setNesting, int useSetId)
        {
            Name = name;
            Path = path;
            ItemInSet = itemInSet;
            SetTag = setTag;
            SetNesting = setNesting;
            UseSetId = useSetId;
        }
    }
}
