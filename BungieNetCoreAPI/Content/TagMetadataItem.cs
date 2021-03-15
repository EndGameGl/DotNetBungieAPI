using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Content
{
    public class TagMetadataItem
    {
        public string Description { get; }
        public string TagText { get; }
        public ReadOnlyCollection<string> Groups { get; }
        public bool IsDefault { get; }
        public string Name { get; }

        [JsonConstructor]
        internal TagMetadataItem(string description, string tagText, string[] groups, bool isDefault, string name)
        {
            Description = description;
            TagText = tagText;
            Groups = groups.AsReadOnlyOrEmpty();
            IsDefault = isDefault;
            Name = name;
        }
    }
}
