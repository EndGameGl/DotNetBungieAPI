namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A specific "spot" referred to by a location. Only one of these can be active at a time for a given Location.
/// </summary>
public class DestinyLocationReleaseDefinition : IDeepEquatable<DestinyLocationReleaseDefinition>
{
    /// <summary>
    ///     Sadly, these don't appear to be populated anymore (ever?)
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    [JsonPropertyName("smallTransparentIcon")]
    public string SmallTransparentIcon { get; set; }

    [JsonPropertyName("mapIcon")]
    public string MapIcon { get; set; }

    [JsonPropertyName("largeTransparentIcon")]
    public string LargeTransparentIcon { get; set; }

    /// <summary>
    ///     If we had map information, this spawnPoint would be interesting. But sadly, we don't have that info.
    /// </summary>
    [JsonPropertyName("spawnPoint")]
    public uint SpawnPoint { get; set; }

    /// <summary>
    ///     The Destination being pointed to by this location.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; set; }

    /// <summary>
    ///     The Activity being pointed to by this location.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     The Activity Graph being pointed to by this location.
    /// </summary>
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; set; }

    /// <summary>
    ///     The Activity Graph Node being pointed to by this location. (Remember that Activity Graph Node hashes are only unique within an Activity Graph: so use the combination to find the node being spoken of)
    /// </summary>
    [JsonPropertyName("activityGraphNodeHash")]
    public uint ActivityGraphNodeHash { get; set; }

    /// <summary>
    ///     The Activity Bubble within the Destination. Look this up in the DestinyDestinationDefinition's bubbles and bubbleSettings properties.
    /// </summary>
    [JsonPropertyName("activityBubbleName")]
    public uint ActivityBubbleName { get; set; }

    /// <summary>
    ///     If we had map information, this would tell us something cool about the path this location wants you to take. I wish we had map information.
    /// </summary>
    [JsonPropertyName("activityPathBundle")]
    public uint ActivityPathBundle { get; set; }

    /// <summary>
    ///     If we had map information, this would tell us about path information related to destination on the map. Sad. Maybe you can do something cool with it. Go to town man.
    /// </summary>
    [JsonPropertyName("activityPathDestination")]
    public uint ActivityPathDestination { get; set; }

    /// <summary>
    ///     The type of Nav Point that this represents. See the enumeration for more info.
    /// </summary>
    [JsonPropertyName("navPointType")]
    public Destiny.DestinyActivityNavPointType NavPointType { get; set; }

    /// <summary>
    ///     Looks like it should be the position on the map, but sadly it does not look populated... yet?
    /// </summary>
    [JsonPropertyName("worldPosition")]
    public List<int> WorldPosition { get; set; }

    public bool DeepEquals(DestinyLocationReleaseDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               SmallTransparentIcon == other.SmallTransparentIcon &&
               MapIcon == other.MapIcon &&
               LargeTransparentIcon == other.LargeTransparentIcon &&
               SpawnPoint == other.SpawnPoint &&
               DestinationHash == other.DestinationHash &&
               ActivityHash == other.ActivityHash &&
               ActivityGraphHash == other.ActivityGraphHash &&
               ActivityGraphNodeHash == other.ActivityGraphNodeHash &&
               ActivityBubbleName == other.ActivityBubbleName &&
               ActivityPathBundle == other.ActivityPathBundle &&
               ActivityPathDestination == other.ActivityPathDestination &&
               NavPointType == other.NavPointType &&
               WorldPosition.DeepEqualsListNaive(other.WorldPosition);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyLocationReleaseDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (SmallTransparentIcon != other.SmallTransparentIcon)
        {
            SmallTransparentIcon = other.SmallTransparentIcon;
            OnPropertyChanged(nameof(SmallTransparentIcon));
        }
        if (MapIcon != other.MapIcon)
        {
            MapIcon = other.MapIcon;
            OnPropertyChanged(nameof(MapIcon));
        }
        if (LargeTransparentIcon != other.LargeTransparentIcon)
        {
            LargeTransparentIcon = other.LargeTransparentIcon;
            OnPropertyChanged(nameof(LargeTransparentIcon));
        }
        if (SpawnPoint != other.SpawnPoint)
        {
            SpawnPoint = other.SpawnPoint;
            OnPropertyChanged(nameof(SpawnPoint));
        }
        if (DestinationHash != other.DestinationHash)
        {
            DestinationHash = other.DestinationHash;
            OnPropertyChanged(nameof(DestinationHash));
        }
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
        if (ActivityGraphHash != other.ActivityGraphHash)
        {
            ActivityGraphHash = other.ActivityGraphHash;
            OnPropertyChanged(nameof(ActivityGraphHash));
        }
        if (ActivityGraphNodeHash != other.ActivityGraphNodeHash)
        {
            ActivityGraphNodeHash = other.ActivityGraphNodeHash;
            OnPropertyChanged(nameof(ActivityGraphNodeHash));
        }
        if (ActivityBubbleName != other.ActivityBubbleName)
        {
            ActivityBubbleName = other.ActivityBubbleName;
            OnPropertyChanged(nameof(ActivityBubbleName));
        }
        if (ActivityPathBundle != other.ActivityPathBundle)
        {
            ActivityPathBundle = other.ActivityPathBundle;
            OnPropertyChanged(nameof(ActivityPathBundle));
        }
        if (ActivityPathDestination != other.ActivityPathDestination)
        {
            ActivityPathDestination = other.ActivityPathDestination;
            OnPropertyChanged(nameof(ActivityPathDestination));
        }
        if (NavPointType != other.NavPointType)
        {
            NavPointType = other.NavPointType;
            OnPropertyChanged(nameof(NavPointType));
        }
        if (!WorldPosition.DeepEqualsListNaive(other.WorldPosition))
        {
            WorldPosition = other.WorldPosition;
            OnPropertyChanged(nameof(WorldPosition));
        }
    }
}