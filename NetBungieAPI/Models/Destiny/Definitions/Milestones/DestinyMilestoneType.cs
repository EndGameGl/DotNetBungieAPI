namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    /// <summary>
    ///     The type of milestone. Milestones can be Tutorials, one-time/triggered/non-repeating but not necessarily tutorials,
    ///     or Repeating Milestones.
    /// </summary>
    public enum DestinyMilestoneType
    {
        Unknown = 0,

        /// <summary>
        ///     One-time milestones that are specifically oriented toward teaching players about new mechanics and gameplay modes.
        /// </summary>
        Tutorial = 1,

        /// <summary>
        ///     Milestones that, once completed a single time, can never be repeated.
        /// </summary>
        OneTime = 2,

        /// <summary>
        ///     Milestones that repeat/reset on a weekly basis. They need not all reset on the same day or time, but do need to
        ///     reset weekly to qualify for this type.
        /// </summary>
        Weekly = 3,

        /// <summary>
        ///     Milestones that repeat or reset on a daily basis.
        /// </summary>
        Daily = 4,

        /// <summary>
        ///     Special indicates that the event is not on a daily/weekly cadence, but does occur more than once. For instance,
        ///     Iron Banner in Destiny 1 or the Dawning were examples of what could be termed "Special" events.
        /// </summary>
        Special = 5
    }
}