using Newtonsoft.Json;
namespace BungieNetCoreAPI.Destiny.Definitions.Races
{
    public class RaceGenderedNames : IDeepEquatable<RaceGenderedNames>
    {
        public string Female { get; }
        public string Male { get; }

        [JsonConstructor]
        internal RaceGenderedNames(string Female, string Male)
        {
            this.Female = Female;
            this.Male = Male;
        }

        public bool DeepEquals(RaceGenderedNames other)
        {
            return other != null &&
                   Female == other.Female &&
                   Male == other.Male;
        }
    }
}
