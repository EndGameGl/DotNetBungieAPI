using NetBungieAPI.Attributes;
using System;

namespace NetBungieAPI.Repositories
{
    public class DefinitionUseRule
    {
        public DestinyDefinitionAttribute AttributeData { get; internal set; }
        public Type DefinitionType { get; internal set; }
    }
}
