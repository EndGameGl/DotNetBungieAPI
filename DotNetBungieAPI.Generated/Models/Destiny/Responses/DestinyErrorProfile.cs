namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     If a Destiny Profile can't be returned, but we're pretty certain it's a valid Destiny account, this will contain as much info as we can get about the profile for your use.
/// <para />
///     Assume that the most you'll get is the Error Code, the Membership Type and the Membership ID.
/// </summary>
public class DestinyErrorProfile : IDeepEquatable<DestinyErrorProfile>
{
    /// <summary>
    ///     The error that we encountered. You should be able to look up localized text to show to the user for these failures.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public Exceptions.PlatformErrorCodes ErrorCode { get; set; }

    /// <summary>
    ///     Basic info about the account that failed. Don't expect anything other than membership ID, Membership Type, and displayName to be populated.
    /// </summary>
    [JsonPropertyName("infoCard")]
    public User.UserInfoCard InfoCard { get; set; }

    public bool DeepEquals(DestinyErrorProfile? other)
    {
        return other is not null &&
               ErrorCode == other.ErrorCode &&
               (InfoCard is not null ? InfoCard.DeepEquals(other.InfoCard) : other.InfoCard is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyErrorProfile? other)
    {
        if (other is null) return;
        if (ErrorCode != other.ErrorCode)
        {
            ErrorCode = other.ErrorCode;
            OnPropertyChanged(nameof(ErrorCode));
        }
        if (!InfoCard.DeepEquals(other.InfoCard))
        {
            InfoCard.Update(other.InfoCard);
            OnPropertyChanged(nameof(InfoCard));
        }
    }
}