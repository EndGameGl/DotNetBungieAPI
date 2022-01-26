namespace DotNetBungieAPI.Generated.Models.User;

public class UserToUserContext : IDeepEquatable<UserToUserContext>
{
    [JsonPropertyName("isFollowing")]
    public bool IsFollowing { get; set; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse IgnoreStatus { get; set; }

    [JsonPropertyName("globalIgnoreEndDate")]
    public DateTime? GlobalIgnoreEndDate { get; set; }

    public bool DeepEquals(UserToUserContext? other)
    {
        return other is not null &&
               IsFollowing == other.IsFollowing &&
               (IgnoreStatus is not null ? IgnoreStatus.DeepEquals(other.IgnoreStatus) : other.IgnoreStatus is null) &&
               GlobalIgnoreEndDate == other.GlobalIgnoreEndDate;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(UserToUserContext? other)
    {
        if (other is null) return;
        if (IsFollowing != other.IsFollowing)
        {
            IsFollowing = other.IsFollowing;
            OnPropertyChanged(nameof(IsFollowing));
        }
        if (!IgnoreStatus.DeepEquals(other.IgnoreStatus))
        {
            IgnoreStatus.Update(other.IgnoreStatus);
            OnPropertyChanged(nameof(IgnoreStatus));
        }
        if (GlobalIgnoreEndDate != other.GlobalIgnoreEndDate)
        {
            GlobalIgnoreEndDate = other.GlobalIgnoreEndDate;
            OnPropertyChanged(nameof(GlobalIgnoreEndDate));
        }
    }
}