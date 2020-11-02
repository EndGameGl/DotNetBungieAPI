using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Classes
{
    public class ClassGenderedNames
    {
        public string Female { get; }
        public string Male { get; }

        [JsonConstructor]
        private ClassGenderedNames(string Female, string Male)
        {
            this.Female = Female;
            this.Male = Male;
        }
    }
}
