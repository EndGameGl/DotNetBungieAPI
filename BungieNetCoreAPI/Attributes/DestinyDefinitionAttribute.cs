using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Attributes
{
    public class DestinyDefinitionAttribute : Attribute
    {
        public string DefinitionName { get; }
        public DestinyDefinitionAttribute(string name)
        {
            DefinitionName = name;
        }
    }
}
