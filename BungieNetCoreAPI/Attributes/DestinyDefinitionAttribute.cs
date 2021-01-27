using BungieNetCoreAPI.Destiny;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Attributes
{
    public class DestinyDefinitionAttribute : Attribute
    {
        public DefinitionsEnum DefinitionEnumType { get; }
        public bool PresentInSQLiteDB { get; }
        public bool ShouldBeLoaded { get; }
        public DestinyDefinitionAttribute(DefinitionsEnum type, bool presentInSQLiteDB = true, bool shouldBeLoaded = true)
        {
            DefinitionEnumType = type;
            PresentInSQLiteDB = presentInSQLiteDB;
            ShouldBeLoaded = shouldBeLoaded;
        }
    }
}
