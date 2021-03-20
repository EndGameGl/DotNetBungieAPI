using Newtonsoft.Json;

namespace NetBungieAPI.GroupsV2
{
    public class GroupTheme
    {
        public string Name { get; }
        public string Folder { get; }
        public string Description { get; }

        [JsonConstructor]
        internal GroupTheme(string name, string folder, string description)
        {
            Name = name;
            Folder = folder;
            Description = description;
        }
    }
}
