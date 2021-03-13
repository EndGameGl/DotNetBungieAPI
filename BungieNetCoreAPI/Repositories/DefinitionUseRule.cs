using NetBungieApi.Attributes;
using NetBungieApi.Destiny;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieApi.Repositories
{
    public class DefinitionUseRule
    {
        public DestinyDefinitionAttribute AttributeData { get; internal set; }
        public Type DefinitionType { get; internal set; }
        public string DefinitionStringName { get; internal set; }
        public bool? UserOverrideLoadValue { get; internal set; }
    }
}
