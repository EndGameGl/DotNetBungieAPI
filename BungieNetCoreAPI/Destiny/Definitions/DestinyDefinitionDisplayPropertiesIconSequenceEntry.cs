using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions
{
    public class DestinyDefinitionDisplayPropertiesIconSequenceEntry
    {
        public List<string> Frames { get; }

        [JsonConstructor]
        private DestinyDefinitionDisplayPropertiesIconSequenceEntry(List<string> frames)
        {
            Frames = frames;
        }
    }
}
