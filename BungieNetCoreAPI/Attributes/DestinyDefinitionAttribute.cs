using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Attributes
{
    public class DestinyDefinitionAttribute : Attribute
    {
        public string DefinitionName { get; }
        public bool IgnoreLoad { get; }
        public DestinyDefinitionAttribute(string name, bool ignoreLoad = false)
        {
            DefinitionName = name;
            IgnoreLoad = ignoreLoad;
        }
    }
}
