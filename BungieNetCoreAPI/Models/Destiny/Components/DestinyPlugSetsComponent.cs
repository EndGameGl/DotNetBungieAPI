using NetBungieAPI.Models.Destiny.Definitions.PlugSets;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyPlugSetsComponent
    {
        [JsonPropertyName("plugs")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyPlugSetDefinition>, object[]> Plugs { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyPlugSetDefinition>, object[]>();
    }
}
