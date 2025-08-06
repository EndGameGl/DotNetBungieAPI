namespace DotNetBungieAPI.Models.Destiny;

[System.Flags]
public enum FireteamFinderOptionAvailability : int
{
    None = 0,

    CreateListingBuilder = 1,

    SearchListingBuilder = 2,

    ListingViewer = 4,

    LobbyViewer = 8
}
