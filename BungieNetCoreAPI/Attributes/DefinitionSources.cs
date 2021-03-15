using System;

namespace NetBungieAPI.Attributes
{
    [Flags]
    public enum DefinitionSources : byte
    {
        None = 0,
        BungieNet = 1 << 0,
        JSON = 1 << 1,
        SQLite = 1 << 2,
        All = BungieNet | JSON | SQLite
    }
}
