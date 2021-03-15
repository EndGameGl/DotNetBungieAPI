using Newtonsoft.Json;

namespace NetBungieAPI.Bungie
{
    public class EmailSettingLocalization
    {
        public string Title { get; }
        public string Description { get; }

        [JsonConstructor]
        internal EmailSettingLocalization(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
