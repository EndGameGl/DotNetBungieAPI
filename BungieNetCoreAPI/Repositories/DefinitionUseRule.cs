using BungieNetCoreAPI.Destiny;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Repositories
{
    public class DefinitionUseRule
    {
        public DefinitionsEnum Type { get; internal set; }
        public Type DefinitionType { get; internal set; }
        public string DefinitionName { get; internal set; }
        public bool IsEnabled { get; internal set; }
        public bool PresentInSQLiteDB { get; internal set; }
    }
}
