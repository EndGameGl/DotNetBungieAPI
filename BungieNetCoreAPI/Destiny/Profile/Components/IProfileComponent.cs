namespace NetBungieAPI.Destiny.Profile.Components
{
    public interface IProfileComponent
    {
        ComponentPrivacy Privacy { get; init; }
        bool? IsDisabled { get; init; }
    }
}
