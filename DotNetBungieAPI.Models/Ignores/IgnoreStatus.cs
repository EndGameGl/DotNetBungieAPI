﻿namespace DotNetBungieAPI.Models.Ignores;

[Flags]
public enum IgnoreStatus
{
    NotIgnored = 0,
    IgnoredUser = 1,
    IgnoredGroup = 2,
    IgnoredByGroup = 4,
    IgnoredPost = 8,
    IgnoredTag = 16,
    IgnoredGlobal = 32
}
