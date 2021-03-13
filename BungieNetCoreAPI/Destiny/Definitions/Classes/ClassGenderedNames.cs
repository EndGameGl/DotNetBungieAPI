using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Classes
{
    public class ClassGenderedNames : IDeepEquatable<ClassGenderedNames>
    {
        public string Female { get; }
        public string Male { get; }

        [JsonConstructor]
        internal ClassGenderedNames(string Female, string Male)
        {
            this.Female = Female;
            this.Male = Male;
        }

        public bool DeepEquals(ClassGenderedNames other)
        {
            return other != null &&
                Female == other.Female &&
                Male == other.Male;
        }
    }
}
