﻿using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Genders
{
    [DestinyDefinition(name: "DestinyGenderDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyGenderDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyGenderTypes GenderType { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyGenderDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyGenderTypes genderType, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            GenderType = genderType;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
