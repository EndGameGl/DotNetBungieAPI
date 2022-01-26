namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If a vendor can ever end up performing actions, these are the properties that will be related to those actions. I'm not going to bother documenting this yet, as it is unused and unclear if it will ever be used... but in case it is ever populated and someone finds it useful, it is defined here.
/// </summary>
public class DestinyVendorActionDefinition : IDeepEquatable<DestinyVendorActionDefinition>
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("executeSeconds")]
    public int ExecuteSeconds { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("verb")]
    public string Verb { get; set; }

    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; set; }

    [JsonPropertyName("actionId")]
    public string ActionId { get; set; }

    [JsonPropertyName("actionHash")]
    public uint ActionHash { get; set; }

    [JsonPropertyName("autoPerformAction")]
    public bool AutoPerformAction { get; set; }

    public bool DeepEquals(DestinyVendorActionDefinition? other)
    {
        return other is not null &&
               Description == other.Description &&
               ExecuteSeconds == other.ExecuteSeconds &&
               Icon == other.Icon &&
               Name == other.Name &&
               Verb == other.Verb &&
               IsPositive == other.IsPositive &&
               ActionId == other.ActionId &&
               ActionHash == other.ActionHash &&
               AutoPerformAction == other.AutoPerformAction;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorActionDefinition? other)
    {
        if (other is null) return;
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
        if (ExecuteSeconds != other.ExecuteSeconds)
        {
            ExecuteSeconds = other.ExecuteSeconds;
            OnPropertyChanged(nameof(ExecuteSeconds));
        }
        if (Icon != other.Icon)
        {
            Icon = other.Icon;
            OnPropertyChanged(nameof(Icon));
        }
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (Verb != other.Verb)
        {
            Verb = other.Verb;
            OnPropertyChanged(nameof(Verb));
        }
        if (IsPositive != other.IsPositive)
        {
            IsPositive = other.IsPositive;
            OnPropertyChanged(nameof(IsPositive));
        }
        if (ActionId != other.ActionId)
        {
            ActionId = other.ActionId;
            OnPropertyChanged(nameof(ActionId));
        }
        if (ActionHash != other.ActionHash)
        {
            ActionHash = other.ActionHash;
            OnPropertyChanged(nameof(ActionHash));
        }
        if (AutoPerformAction != other.AutoPerformAction)
        {
            AutoPerformAction = other.AutoPerformAction;
            OnPropertyChanged(nameof(AutoPerformAction));
        }
    }
}