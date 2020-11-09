using Newtonsoft.Json;
namespace BungieNetCoreAPI.Destiny.Definitions.Races
{
    public class RaceGenderedNames
    {
        public string Female { get; }
        public string Male { get; }

        [JsonConstructor]
        private RaceGenderedNames(string Female, string Male)
        {
            this.Female = Female;
            this.Male = Male;
        }
    }
}
