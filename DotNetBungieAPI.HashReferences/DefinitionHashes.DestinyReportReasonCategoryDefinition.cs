namespace DotNetBungieAPI.HashReferences
{
    public static partial class DefinitionHashes
    {
        public static class ReportReasonCategories
        {
            /// <summary>
            /// 	Exploits are use of bugs or glitches in the game not intended by the game designers, that players take advantage of for personal benefit.
            /// <para/>
            /// 	Examples: Exploiting Game, Exploiting Map
            /// <para/>
            /// </summary>
            public const uint Exploiting = 2032714362;

            /// <summary>
            /// 	A bad connection may cause a player to move around unnaturally in world, be unresponsive, or disconnect. This player is not believed to be doing this intentionally.
            /// <para/>
            /// 	Examples: Moderate, Severe
            /// <para/>
            /// </summary>
            public const uint BadConnection = 1480507937;

            /// <summary>
            /// 	Griefing intentionally irritates other players, often using the game in unintended ways to do so.
            /// <para/>
            /// 	Examples: Sabotage, Kicked from fireteam
            /// <para/>
            /// </summary>
            public const uint Griefing = 2813366390;

            /// <summary>
            /// 	Player intentionally quits during an activity.
            /// <para/>
            /// 	Examples: Quit at start, Quit mid-activity
            /// <para/>
            /// </summary>
            public const uint Quitting = 1053168648;

            /// <summary>
            /// 	Inactivity includes being intentionally absent or inactive during gameplay.
            /// <para/>
            /// 	Examples: AFK, Using bots
            /// <para/>
            /// </summary>
            public const uint Inactivity = 2425050023;

            /// <summary>
            /// 	Cheating involves using methods outside of the game to create an advantage or disadvantage beyond the normal gameplay.
            /// <para/>
            /// 	Examples: Hacking, Network Manipulation
            /// <para/>
            /// </summary>
            public const uint Cheating = 1851805954;

            /// <summary>
            /// 	Verbal abuse is the delivery of hateful communications.
            /// <para/>
            /// 	Examples: Yelling, Vulgar Language
            /// <para/>
            /// </summary>
            public const uint VerbalAbuse = 4291247038;

            /// <summary>
            /// 	Unsolicited invitations or messages sent frequently or to large numbers of recipients.
            /// <para/>
            /// 	Examples: Friend Invite, Whisper, Chat.
            /// <para/>
            /// </summary>
            public const uint Spam = 3542520966;

            /// <summary>
            /// 	Abusive chat is any form of hateful, discriminatory, or obscene communications. Threatening or harassing others is unacceptable, regardless of the words used.
            /// <para/>
            /// 	Examples: Insult, Harassment
            /// <para/>
            /// </summary>
            public const uint AbusiveChat = 1225860615;
        }
    }
}
