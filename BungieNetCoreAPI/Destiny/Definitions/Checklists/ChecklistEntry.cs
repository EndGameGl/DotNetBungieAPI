using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Checklists
{
    public class ChecklistEntry
    {
        public uint BubbleHash { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint Hash { get; }
        public int Scope { get; }

        [JsonConstructor]
        private ChecklistEntry(uint bubbleHash, uint destinationHash, DestinyDefinitionDisplayProperties displayProperties, uint hash, int scope)
        {
            BubbleHash = bubbleHash;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, "DestinyDestinationDefinition");
            DisplayProperties = displayProperties;
            Hash = hash;
            Scope = scope;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }
    }
}
