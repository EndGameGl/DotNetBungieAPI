using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public record EmailViewDefinition
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("viewSettings")]
        public ReadOnlyCollection<EmailViewDefinitionSetting> ViewSettings { get; init; } = Defaults.EmptyReadOnlyCollection<EmailViewDefinitionSetting>();
    }
}
