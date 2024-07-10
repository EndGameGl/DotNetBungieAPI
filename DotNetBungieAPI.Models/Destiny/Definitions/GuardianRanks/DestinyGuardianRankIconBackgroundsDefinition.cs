namespace DotNetBungieAPI.Models.Destiny.Definitions.GuardianRanks;

public sealed record DestinyGuardianRankIconBackgroundsDefinition
    : IDeepEquatable<DestinyGuardianRankIconBackgroundsDefinition>
{
    [JsonPropertyName("backgroundEmptyBorderedImagePath")]
    public string BackgroundEmptyBorderedImagePath { get; init; }

    [JsonPropertyName("backgroundEmptyBlueGradientBorderedImagePath")]
    public string BackgroundEmptyBlueGradientBorderedImagePath { get; init; }

    [JsonPropertyName("backgroundFilledBlueBorderedImagePath")]
    public string BackgroundFilledBlueBorderedImagePath { get; init; }

    [JsonPropertyName("backgroundFilledBlueGradientBorderedImagePath")]
    public string BackgroundFilledBlueGradientBorderedImagePath { get; init; }

    [JsonPropertyName("backgroundFilledBlueLowAlphaImagePath")]
    public string BackgroundFilledBlueLowAlphaImagePath { get; init; }

    [JsonPropertyName("backgroundFilledBlueMediumAlphaImagePath")]
    public string BackgroundFilledBlueMediumAlphaImagePath { get; init; }

    [JsonPropertyName("backgroundFilledGrayMediumAlphaBorderedImagePath")]
    public string BackgroundFilledGrayMediumAlphaBorderedImagePath { get; init; }

    [JsonPropertyName("backgroundFilledGrayHeavyAlphaBorderedImagePath")]
    public string BackgroundFilledGrayHeavyAlphaBorderedImagePath { get; init; }

    [JsonPropertyName("backgroundFilledWhiteMediumAlphaImagePath")]
    public string BackgroundFilledWhiteMediumAlphaImagePath { get; init; }

    [JsonPropertyName("backgroundFilledWhiteImagePath")]
    public string BackgroundFilledWhiteImagePath { get; init; }

    [JsonPropertyName("backgroundPlateWhiteImagePath")]
    public string BackgroundPlateWhiteImagePath { get; init; }

    [JsonPropertyName("backgroundPlateBlackImagePath")]
    public string BackgroundPlateBlackImagePath { get; init; }

    [JsonPropertyName("backgroundPlateBlackAlphaImagePath")]
    public string BackgroundPlateBlackAlphaImagePath { get; init; }

    public bool DeepEquals(DestinyGuardianRankIconBackgroundsDefinition other)
    {
        return other is not null
            && BackgroundEmptyBorderedImagePath == other.BackgroundEmptyBorderedImagePath
            && BackgroundEmptyBlueGradientBorderedImagePath
                == other.BackgroundEmptyBlueGradientBorderedImagePath
            && BackgroundFilledBlueBorderedImagePath == other.BackgroundFilledBlueBorderedImagePath
            && BackgroundFilledBlueGradientBorderedImagePath
                == other.BackgroundFilledBlueGradientBorderedImagePath
            && BackgroundFilledBlueLowAlphaImagePath == other.BackgroundFilledBlueLowAlphaImagePath
            && BackgroundFilledBlueMediumAlphaImagePath
                == other.BackgroundFilledBlueMediumAlphaImagePath
            && BackgroundFilledGrayMediumAlphaBorderedImagePath
                == other.BackgroundFilledGrayMediumAlphaBorderedImagePath
            && BackgroundFilledGrayHeavyAlphaBorderedImagePath
                == other.BackgroundFilledGrayHeavyAlphaBorderedImagePath
            && BackgroundFilledWhiteMediumAlphaImagePath
                == other.BackgroundFilledWhiteMediumAlphaImagePath
            && BackgroundFilledWhiteImagePath == other.BackgroundFilledWhiteImagePath
            && BackgroundPlateWhiteImagePath == other.BackgroundPlateWhiteImagePath
            && BackgroundPlateBlackImagePath == other.BackgroundPlateBlackImagePath
            && BackgroundPlateBlackAlphaImagePath == other.BackgroundPlateBlackAlphaImagePath;
    }
}
