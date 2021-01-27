using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions
{
    public class DestinyDefinitionDisplayPropertiesIconSequenceEntry : IDeepEquatable<DestinyDefinitionDisplayPropertiesIconSequenceEntry>
    {
        public ReadOnlyCollection<string> Frames { get; }

        [JsonConstructor]
        private DestinyDefinitionDisplayPropertiesIconSequenceEntry(string[] frames)
        {
            Frames = frames.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(DestinyDefinitionDisplayPropertiesIconSequenceEntry other)
        {
            return Frames.DeepEqualsReadOnlySimpleCollection(other.Frames);
        }
    }
}
