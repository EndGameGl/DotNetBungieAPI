using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Data.Models;
using DotNetBungieAPI.Data.Models.Activities;
using DotNetBungieAPI.Data.Models.Profiles;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Data;

public static class Destiny2DataExtensions
{
    private static readonly DestinyComponentType[] GetBungieNetProfileProfileComponentTypes =
    {
        DestinyComponentType.Profiles,
        DestinyComponentType.Characters
    };

    public static async ValueTask<BungieNetProfile> GetBungieNetProfile(
        this IBungieClient bungieClient,
        long bungieNetId,
        CancellationToken cancellationToken = default)
    {
        var profileData = new BungieNetProfile();

        var membershipData =
            await bungieClient.ApiAccess.User.GetMembershipDataById(
                bungieNetId,
                BungieMembershipType.All,
                cancellationToken);

        if (!membershipData.IsSuccessfulResponseCode)
        {
            throw membershipData.ToException();
        }

        profileData.MembershipData = membershipData.Response;

        foreach (var destinyMembership in membershipData.Response.DestinyMemberships)
        {
            var profileResponse = await bungieClient.ApiAccess.Destiny2.GetProfile(
                destinyMembership.MembershipType,
                destinyMembership.MembershipId,
                GetBungieNetProfileProfileComponentTypes,
                null,
                cancellationToken);

            if (!profileResponse.IsSuccessfulResponseCode)
            {
                throw profileResponse.ToException();
            }

            profileData.Profiles.Add(
                new DestinyProfileAndCharacters()
                {
                    Characters = profileResponse.Response.Characters.Data,
                    Profile = profileResponse.Response.Profile.Data
                });
        }

        return profileData;
    }

    public static async ValueTask<CharacterActivities> GetCharacterActivityData(
        this IBungieClient bungieClient,
        BungieMembershipType membershipType,
        long destinyMembershipId,
        long characterId,
        AuthorizationTokenData token,
        CancellationToken cancellationToken)
    {
        var profileResponse = await bungieClient.ApiAccess.Destiny2.GetProfile(
            membershipType,
            destinyMembershipId,
            new[]
            {
                DestinyComponentType.CharacterActivities
            },
            token,
            cancellationToken);
        
        if (!profileResponse.IsSuccessfulResponseCode)
        {
            throw profileResponse.ToException();
        }

        var activitiesData = profileResponse.Response.CharacterActivities.Data[characterId];

        var destinyActivitiesData = new List<DestinyActivityData>(activitiesData.AvailableActivities.Count);

        foreach (var activity in activitiesData.AvailableActivities)
        {
            if (activity.Activity.TryGetDefinition(out var activityDefinition))
            {
                destinyActivitiesData.Add(new DestinyActivityData()
                {
                    RuntimeActivityData = activity,
                    ActivityDefinition = activityDefinition
                });
            }
        }

        return new CharacterActivities()
        { 
            ActivitiesData = destinyActivitiesData
        };
    }
}