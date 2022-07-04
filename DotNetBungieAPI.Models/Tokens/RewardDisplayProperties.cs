namespace DotNetBungieAPI.Models.Tokens;

public class RewardDisplayProperties
{
    [JsonPropertyName("Name")]
    public string Name { get; init; }
    
    [JsonPropertyName("Description")]
    public string Description { get; init; }
    
    [JsonPropertyName("ImagePath")]
    public string ImagePath { get; init; }
}