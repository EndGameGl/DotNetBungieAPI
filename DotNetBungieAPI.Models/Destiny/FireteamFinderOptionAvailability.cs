namespace DotNetBungieAPI.Models.Destiny;

[Flags]
public enum FireteamFinderOptionAvailability
{
    None = 0,
    CreateListingBuilder = 1,
    SearchListingBuilder = 2,
    ListingViewer = 4,
    LobbyViewer = 8,
}
