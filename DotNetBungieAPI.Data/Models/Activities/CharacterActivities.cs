namespace DotNetBungieAPI.Data.Models.Activities;

public class CharacterActivities
{
    public List<DestinyActivityData> ActivitiesData { get; internal set; }

    public IEnumerable<DestinyActivityData> UncompletedActivities =>
        ActivitiesData.Where(x => x.RuntimeActivityData.IsCompleted == false);

    public IEnumerable<DestinyActivityData> NewActivities =>
        ActivitiesData.Where(x => x.RuntimeActivityData.IsNew);

    public IEnumerable<DestinyActivityData> VisibleActivities =>
        ActivitiesData.Where(x => x.RuntimeActivityData.IsVisible);

    public IEnumerable<DestinyActivityData> Playlists =>
        ActivitiesData.Where(x => x.ActivityDefinition.IsPlaylist);

    public IEnumerable<DestinyActivityData> PvP =>
        ActivitiesData.Where(x => x.ActivityDefinition.IsPvP);
    
    public IEnumerable<DestinyActivityData> PvE =>
        ActivitiesData.Where(x => !x.ActivityDefinition.IsPvP);
}