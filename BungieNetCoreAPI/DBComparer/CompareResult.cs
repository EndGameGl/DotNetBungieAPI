using NetBungieAPI.Destiny;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.DBComparer
{
    public class CompareResult
    {
        public DestinyLocales Locale { get; set; }
        public DefinitionsEnum Definition { get; set; }
        public uint Hash { get; set; }
        public string Older { get; set; }
        public string Newer { get; set; }
        public bool WasUpdated { get; set; } = false;
        public bool IsNew { get; set; } = false;
    }
}
