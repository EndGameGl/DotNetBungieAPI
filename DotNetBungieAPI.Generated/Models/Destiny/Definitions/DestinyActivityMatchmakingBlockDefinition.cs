namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Information about matchmaking and party size for the activity.
/// </summary>
public class DestinyActivityMatchmakingBlockDefinition : IDeepEquatable<DestinyActivityMatchmakingBlockDefinition>
{
    /// <summary>
    ///     If TRUE, the activity is matchmade. Otherwise, it requires explicit forming of a party.
    /// </summary>
    [JsonPropertyName("isMatchmade")]
    public bool IsMatchmade { get; set; }

    /// <summary>
    ///     The minimum # of people in the fireteam for the activity to launch.
    /// </summary>
    [JsonPropertyName("minParty")]
    public int MinParty { get; set; }

    /// <summary>
    ///     The maximum # of people allowed in a Fireteam.
    /// </summary>
    [JsonPropertyName("maxParty")]
    public int MaxParty { get; set; }

    /// <summary>
    ///     The maximum # of people allowed across all teams in the activity.
    /// </summary>
    [JsonPropertyName("maxPlayers")]
    public int MaxPlayers { get; set; }

    /// <summary>
    ///     If true, you have to Solemnly Swear to be up to Nothing But Good(tm) to play.
    /// </summary>
    [JsonPropertyName("requiresGuardianOath")]
    public bool RequiresGuardianOath { get; set; }

    public bool DeepEquals(DestinyActivityMatchmakingBlockDefinition? other)
    {
        return other is not null &&
               IsMatchmade == other.IsMatchmade &&
               MinParty == other.MinParty &&
               MaxParty == other.MaxParty &&
               MaxPlayers == other.MaxPlayers &&
               RequiresGuardianOath == other.RequiresGuardianOath;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityMatchmakingBlockDefinition? other)
    {
        if (other is null) return;
        if (IsMatchmade != other.IsMatchmade)
        {
            IsMatchmade = other.IsMatchmade;
            OnPropertyChanged(nameof(IsMatchmade));
        }
        if (MinParty != other.MinParty)
        {
            MinParty = other.MinParty;
            OnPropertyChanged(nameof(MinParty));
        }
        if (MaxParty != other.MaxParty)
        {
            MaxParty = other.MaxParty;
            OnPropertyChanged(nameof(MaxParty));
        }
        if (MaxPlayers != other.MaxPlayers)
        {
            MaxPlayers = other.MaxPlayers;
            OnPropertyChanged(nameof(MaxPlayers));
        }
        if (RequiresGuardianOath != other.RequiresGuardianOath)
        {
            RequiresGuardianOath = other.RequiresGuardianOath;
            OnPropertyChanged(nameof(RequiresGuardianOath));
        }
    }
}