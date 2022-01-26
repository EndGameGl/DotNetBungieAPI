namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupOptionsEditAction : IDeepEquatable<GroupOptionsEditAction>
{
    /// <summary>
    ///     Minimum Member Level allowed to invite new members to group
    /// <para />
    ///     Always Allowed: Founder, Acting Founder
    /// <para />
    ///     True means admins have this power, false means they don't
    /// <para />
    ///     Default is false for clans, true for groups.
    /// </summary>
    [JsonPropertyName("InvitePermissionOverride")]
    public bool? InvitePermissionOverride { get; set; }

    /// <summary>
    ///     Minimum Member Level allowed to update group culture
    /// <para />
    ///     Always Allowed: Founder, Acting Founder
    /// <para />
    ///     True means admins have this power, false means they don't
    /// <para />
    ///     Default is false for clans, true for groups.
    /// </summary>
    [JsonPropertyName("UpdateCulturePermissionOverride")]
    public bool? UpdateCulturePermissionOverride { get; set; }

    /// <summary>
    ///     Minimum Member Level allowed to host guided games
    /// <para />
    ///     Always Allowed: Founder, Acting Founder, Admin
    /// <para />
    ///     Allowed Overrides: None, Member, Beginner
    /// <para />
    ///     Default is Member for clans, None for groups, although this means nothing for groups.
    /// </summary>
    [JsonPropertyName("HostGuidedGamePermissionOverride")]
    public int? HostGuidedGamePermissionOverride { get; set; }

    /// <summary>
    ///     Minimum Member Level allowed to update banner
    /// <para />
    ///     Always Allowed: Founder, Acting Founder
    /// <para />
    ///     True means admins have this power, false means they don't
    /// <para />
    ///     Default is false for clans, true for groups.
    /// </summary>
    [JsonPropertyName("UpdateBannerPermissionOverride")]
    public bool? UpdateBannerPermissionOverride { get; set; }

    /// <summary>
    ///     Level to join a member at when accepting an invite, application, or joining an open clan
    /// <para />
    ///     Default is Beginner.
    /// </summary>
    [JsonPropertyName("JoinLevel")]
    public int? JoinLevel { get; set; }

    public bool DeepEquals(GroupOptionsEditAction? other)
    {
        return other is not null &&
               InvitePermissionOverride == other.InvitePermissionOverride &&
               UpdateCulturePermissionOverride == other.UpdateCulturePermissionOverride &&
               HostGuidedGamePermissionOverride == other.HostGuidedGamePermissionOverride &&
               UpdateBannerPermissionOverride == other.UpdateBannerPermissionOverride &&
               JoinLevel == other.JoinLevel;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupOptionsEditAction? other)
    {
        if (other is null) return;
        if (InvitePermissionOverride != other.InvitePermissionOverride)
        {
            InvitePermissionOverride = other.InvitePermissionOverride;
            OnPropertyChanged(nameof(InvitePermissionOverride));
        }
        if (UpdateCulturePermissionOverride != other.UpdateCulturePermissionOverride)
        {
            UpdateCulturePermissionOverride = other.UpdateCulturePermissionOverride;
            OnPropertyChanged(nameof(UpdateCulturePermissionOverride));
        }
        if (HostGuidedGamePermissionOverride != other.HostGuidedGamePermissionOverride)
        {
            HostGuidedGamePermissionOverride = other.HostGuidedGamePermissionOverride;
            OnPropertyChanged(nameof(HostGuidedGamePermissionOverride));
        }
        if (UpdateBannerPermissionOverride != other.UpdateBannerPermissionOverride)
        {
            UpdateBannerPermissionOverride = other.UpdateBannerPermissionOverride;
            OnPropertyChanged(nameof(UpdateBannerPermissionOverride));
        }
        if (JoinLevel != other.JoinLevel)
        {
            JoinLevel = other.JoinLevel;
            OnPropertyChanged(nameof(JoinLevel));
        }
    }
}