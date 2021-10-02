using System;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny
{
    /// <summary>
    ///     A Flags enumeration representing the reasons why a person can't join this user's fireteam.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyJoinClosedReasons
    {
        None = 0,

        /// <summary>
        ///     The user is currently in matchmaking.
        /// </summary>
        InMatchmaking = 1,

        /// <summary>
        ///     The user is currently in a loading screen.
        /// </summary>
        Loading = 2,

        /// <summary>
        ///     The user is in an activity that requires solo play.
        /// </summary>
        SoloMode = 4,

        /// <summary>
        ///     The user can't be joined for one of a variety of internal reasons. Basically, the game can't let you join at this
        ///     time, but for reasons that aren't under the control of this user.
        /// </summary>
        InternalReasons = 8,

        /// <summary>
        ///     The user's current activity/quest/other transitory game state is preventing joining.
        /// </summary>
        DisallowedByGameState = 16,

        /// <summary>
        ///     The user appears to be offline.
        /// </summary>
        Offline = 32768
    }
}