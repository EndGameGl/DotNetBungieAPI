﻿using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Repositories
{
    public class DefinitionUseRule
    {
        public DestinyDefinitionAttribute AttributeData { get; internal set; }
        public Type DefinitionType { get; internal set; }
        public string DefinitionStringName { get; internal set; }
        public bool? UserOverrideLoadValue { get; internal set; }
    }
}
