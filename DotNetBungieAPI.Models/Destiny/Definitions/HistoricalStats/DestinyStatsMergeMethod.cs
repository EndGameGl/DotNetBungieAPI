﻿namespace DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

public enum DestinyStatsMergeMethod
{
    /// <summary>
    ///     When collapsing multiple instances of the stat together, add the values.
    /// </summary>
    Add = 0,

    /// <summary>
    ///     When collapsing multiple instances of the stat together, take the lower value.
    /// </summary>
    Min = 1,

    /// <summary>
    ///     When collapsing multiple instances of the stat together, take the higher value.
    /// </summary>
    Max = 2
}
