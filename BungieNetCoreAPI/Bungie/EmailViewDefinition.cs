using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Bungie
{
    public class EmailViewDefinition
    {
        public string Name { get; }
        public ReadOnlyCollection<EmailViewDefinitionSetting> ViewSettings { get; }

        [JsonConstructor]
        internal EmailViewDefinition(string name, EmailViewDefinitionSetting[] viewSettings)
        {
            Name = name;
            ViewSettings = viewSettings.AsReadOnlyOrEmpty();
        }
    }
}
