using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockValues
{
    /// <summary>
    /// Doesn't have any meaning at this moment
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyUnlockValueDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyUnlockValueDefinition : IDestinyDefinition
    {
        /// <summary>
        /// Always 0 atm
        /// </summary>
        public int AggregationType { get; }
        /// <summary>
        /// Always 0 atm
        /// </summary>
        public int Scope { get; }
        /// <summary>
        /// Always 0 atm
        /// </summary>
        public int MappingIndex { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyUnlockValueDefinition(int aggregationType, int scope, int mappingIndex, bool blacklisted, uint hash, int index, bool redacted)
        {
            AggregationType = aggregationType;
            Scope = scope;
            MappingIndex = mappingIndex;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
