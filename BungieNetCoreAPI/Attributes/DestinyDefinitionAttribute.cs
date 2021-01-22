using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Attributes
{
    public class DestinyDefinitionAttribute : Attribute
    {
        public string DefinitionName { get; }
        public bool PresentInSQLiteDB { get; }
        public bool ShouldBeLoaded { get; }
        public DestinyDefinitionAttribute(string name, bool presentInSQLiteDB = true, bool shouldBeLoaded = true)
        {
            DefinitionName = name;
            PresentInSQLiteDB = presentInSQLiteDB;
            ShouldBeLoaded = shouldBeLoaded;
        }
    }
}
