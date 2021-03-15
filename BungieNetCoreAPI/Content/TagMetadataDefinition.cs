using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Content
{
    public class TagMetadataDefinition
    {
        public string Description { get; }
        public int Order { get; }
        public ReadOnlyCollection<TagMetadataItem> Items { get; }
        public string Datatype { get; }
        public string Name { get; }
        public bool IsRequired { get; }

        [JsonConstructor]
        internal TagMetadataDefinition(string description, int order, TagMetadataItem[] items, string datatype, string name, bool isRequired)
        {
            Description = description;
            Order = order;
            Items = items.AsReadOnlyOrEmpty();
            Datatype = datatype;
            Name = name;
            IsRequired = isRequired;
        }
    }
}
