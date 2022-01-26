namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

/// <summary>
///     This is an experimental set of data that Bungie considers to be "transitory" - information that may be useful for API users, but that is coming from a non-authoritative data source about information that could potentially change at a more frequent pace than Bungie.net will receive updates about it.
/// <para />
///     This information is provided exclusively for convenience should any of it be useful to users: we provide no guarantees to the accuracy or timeliness of data that comes from this source. Know that this data can potentially be out-of-date or even wrong entirely if the user disconnected from the game or suddenly changed their status before we can receive refreshed data.
/// </summary>
public class DestinyProfileTransitoryComponent : IDeepEquatable<DestinyProfileTransitoryComponent>
{
    /// <summary>
    ///     If you have any members currently in your party, this is some (very) bare-bones information about those members.
    /// </summary>
    [JsonPropertyName("partyMembers")]
    public List<Destiny.Components.Profiles.DestinyProfileTransitoryPartyMember> PartyMembers { get; set; }

    /// <summary>
    ///     If you are in an activity, this is some transitory info about the activity currently being played.
    /// </summary>
    [JsonPropertyName("currentActivity")]
    public Destiny.Components.Profiles.DestinyProfileTransitoryCurrentActivity CurrentActivity { get; set; }

    /// <summary>
    ///     Information about whether and what might prevent you from joining this person on a fireteam.
    /// </summary>
    [JsonPropertyName("joinability")]
    public Destiny.Components.Profiles.DestinyProfileTransitoryJoinability Joinability { get; set; }

    /// <summary>
    ///     Information about tracked entities.
    /// </summary>
    [JsonPropertyName("tracking")]
    public List<Destiny.Components.Profiles.DestinyProfileTransitoryTrackingEntry> Tracking { get; set; }

    /// <summary>
    ///     The hash identifier for the DestinyDestinationDefinition of the last location you were orbiting when in orbit.
    /// </summary>
    [JsonPropertyName("lastOrbitedDestinationHash")]
    public uint? LastOrbitedDestinationHash { get; set; }

    public bool DeepEquals(DestinyProfileTransitoryComponent? other)
    {
        return other is not null &&
               PartyMembers.DeepEqualsList(other.PartyMembers) &&
               (CurrentActivity is not null ? CurrentActivity.DeepEquals(other.CurrentActivity) : other.CurrentActivity is null) &&
               (Joinability is not null ? Joinability.DeepEquals(other.Joinability) : other.Joinability is null) &&
               Tracking.DeepEqualsList(other.Tracking) &&
               LastOrbitedDestinationHash == other.LastOrbitedDestinationHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProfileTransitoryComponent? other)
    {
        if (other is null) return;
        if (!PartyMembers.DeepEqualsList(other.PartyMembers))
        {
            PartyMembers = other.PartyMembers;
            OnPropertyChanged(nameof(PartyMembers));
        }
        if (!CurrentActivity.DeepEquals(other.CurrentActivity))
        {
            CurrentActivity.Update(other.CurrentActivity);
            OnPropertyChanged(nameof(CurrentActivity));
        }
        if (!Joinability.DeepEquals(other.Joinability))
        {
            Joinability.Update(other.Joinability);
            OnPropertyChanged(nameof(Joinability));
        }
        if (!Tracking.DeepEqualsList(other.Tracking))
        {
            Tracking = other.Tracking;
            OnPropertyChanged(nameof(Tracking));
        }
        if (LastOrbitedDestinationHash != other.LastOrbitedDestinationHash)
        {
            LastOrbitedDestinationHash = other.LastOrbitedDestinationHash;
            OnPropertyChanged(nameof(LastOrbitedDestinationHash));
        }
    }
}