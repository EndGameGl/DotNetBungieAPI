namespace DotNetBungieAPI.Exceptions
{
    public class ReauthRequiredException : Exception
    {
        public ReauthRequiredException(long membershipId) : base(
            $"Refresh token for membership id {membershipId} has expired")
        {
            MembershipId = membershipId;
        }

        public long MembershipId { get; }
    }
}