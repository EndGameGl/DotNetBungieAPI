namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Guided Game information for this activity.
/// </summary>
public class DestinyActivityGuidedBlockDefinition : IDeepEquatable<DestinyActivityGuidedBlockDefinition>
{
    /// <summary>
    ///     The maximum amount of people that can be in the waiting lobby.
    /// </summary>
    [JsonPropertyName("guidedMaxLobbySize")]
    public int GuidedMaxLobbySize { get; set; }

    /// <summary>
    ///     The minimum amount of people that can be in the waiting lobby.
    /// </summary>
    [JsonPropertyName("guidedMinLobbySize")]
    public int GuidedMinLobbySize { get; set; }

    /// <summary>
    ///     If -1, the guided group cannot be disbanded. Otherwise, take the total # of players in the activity and subtract this number: that is the total # of votes needed for the guided group to disband.
    /// </summary>
    [JsonPropertyName("guidedDisbandCount")]
    public int GuidedDisbandCount { get; set; }

    public bool DeepEquals(DestinyActivityGuidedBlockDefinition? other)
    {
        return other is not null &&
               GuidedMaxLobbySize == other.GuidedMaxLobbySize &&
               GuidedMinLobbySize == other.GuidedMinLobbySize &&
               GuidedDisbandCount == other.GuidedDisbandCount;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityGuidedBlockDefinition? other)
    {
        if (other is null) return;
        if (GuidedMaxLobbySize != other.GuidedMaxLobbySize)
        {
            GuidedMaxLobbySize = other.GuidedMaxLobbySize;
            OnPropertyChanged(nameof(GuidedMaxLobbySize));
        }
        if (GuidedMinLobbySize != other.GuidedMinLobbySize)
        {
            GuidedMinLobbySize = other.GuidedMinLobbySize;
            OnPropertyChanged(nameof(GuidedMinLobbySize));
        }
        if (GuidedDisbandCount != other.GuidedDisbandCount)
        {
            GuidedDisbandCount = other.GuidedDisbandCount;
            OnPropertyChanged(nameof(GuidedDisbandCount));
        }
    }
}