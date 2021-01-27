using Newtonsoft.Json;

namespace BungieNetCoreAPI.Bungie
{
    public class EmailViewDefinition
    {
        public string Name { get; }
        public EmailViewDefinitionSetting[] ViewSettings { get; }

        [JsonConstructor]
        internal EmailViewDefinition(string name, EmailViewDefinitionSetting[] viewSettings)
        {
            Name = name;
            ViewSettings = viewSettings;
        }
    }
}
