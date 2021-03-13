namespace NetBungieApi.Destiny.Profile.Components
{
    public interface IProfileComponent
    {
        ComponentPrivacy Privacy { get; }
        bool? IsDisabled { get; }
    }
}
