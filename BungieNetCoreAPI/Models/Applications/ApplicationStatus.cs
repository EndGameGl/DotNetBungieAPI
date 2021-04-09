﻿namespace NetBungieAPI.Models.Applications
{
    public enum ApplicationStatus : int
    {
        None = 0,
        Private = 1,
        Public = 2,
        Disabled = 3,
        Blocked = 4
    }
}