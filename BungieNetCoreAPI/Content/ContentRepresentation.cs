using Newtonsoft.Json;

namespace NetBungieAPI.Content
{
    public class ContentRepresentation
    {
        public string Name { get; }
        public string Path { get; }
        public string ValidationString { get; }

        [JsonConstructor]
        internal ContentRepresentation(string name, string path, string validationString)
        {
            Name = name;
            Path = path;
            ValidationString = validationString;
        }
    }
}
