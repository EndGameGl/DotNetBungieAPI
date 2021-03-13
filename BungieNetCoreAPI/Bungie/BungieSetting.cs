using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Bungie
{
    public class BungieSetting
    {
        public string Identifier { get; }
        public bool IsDefault { get; }
        public string DisplayName { get; }
        public string Summary { get; }
        public string ImagePath { get; }
        public ReadOnlyCollection<BungieSetting> ChildSettings { get; }

        [JsonConstructor]
        internal BungieSetting(string identifier, bool isDefault, string displayName, string summary, string imagePath, BungieSetting[] childSettings)
        {
            Identifier = identifier;
            IsDefault = isDefault;
            DisplayName = displayName;
            Summary = summary;
            ImagePath = imagePath;
            ChildSettings = childSettings.AsReadOnlyOrEmpty();
        }

        public override string ToString()
        {
            return $"{Identifier} : {DisplayName} | {Summary}";
        }
    }
}
