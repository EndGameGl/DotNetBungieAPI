namespace DotNetBungieAPI.Models.Destiny
{
    /// <summary>
    ///     A flags enumeration that represents a Fireteam Member's status.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyPartyMemberStates
    {
        None = 0,

        /// <summary>
        ///     This one's pretty obvious - they're on your Fireteam.
        /// </summary>
        FireteamMember = 1,

        /// <summary>
        ///     I don't know what it means to be in a 'Posse', but apparently this is it.
        /// </summary>
        PosseMember = 2,

        /// <summary>
        ///     Nor do I understand the difference between them being in a 'Group' vs. a 'Fireteam'.
        ///     <para />
        ///     I'll update these docs once I get more info. If I get more info. If you're reading this, I never got more info.
        ///     You're on your own, kid.
        /// </summary>
        GroupMember = 4,

        /// <summary>
        ///     This person is the party leader.
        /// </summary>
        PartyLeader = 8
    }
}