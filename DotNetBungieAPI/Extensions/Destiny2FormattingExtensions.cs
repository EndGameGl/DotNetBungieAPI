using System.Globalization;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Definitions;

namespace DotNetBungieAPI.Extensions;

/// <summary>
///     Extension class for formatting destiny-related values
/// </summary>
public static class Destiny2FormattingExtensions
{
    private static readonly DateTime UnixBaseDate = new DateTime(1970, 1, 1);
    private const string SetCheckbox = "☑";
    private const string UnsetCheckbox = "☐";
    private const string GreenPip = "🟩";
    private const string RedPip = "🟥";

    /// <summary>
    ///     Formats values depending on display type
    /// </summary>
    /// <param name="value">Raw value to format</param>
    /// <param name="objectiveDefinition"><see cref="De"/>></param>
    /// <param name="style">Style in which to format the value</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string FormatUIDisplayValue(this int value, DestinyObjectiveDefinition objectiveDefinition)
    {
        var formattingStyle = ObjectiveIsCompleted(value, objectiveDefinition) ? objectiveDefinition.CompletedValueStyle : objectiveDefinition.InProgressValueStyle;

        return formattingStyle switch
        {
            DestinyUnlockValueUIStyle.Automatic => $"{value}/{objectiveDefinition.CompletionValue}",
            DestinyUnlockValueUIStyle.Fraction => $"{value}/{objectiveDefinition.CompletionValue}",
            DestinyUnlockValueUIStyle.Checkbox => value == 1 ? SetCheckbox : UnsetCheckbox,
            DestinyUnlockValueUIStyle.Percentage => $"{value}%",
            DestinyUnlockValueUIStyle.DateTime => UnixBaseDate.AddSeconds(value).ToString("d"),
            DestinyUnlockValueUIStyle.FractionFloat => "Not implemented, file an issue if you find any",
            DestinyUnlockValueUIStyle.Integer => value.ToString("N0", CultureInfo.InvariantCulture),
            DestinyUnlockValueUIStyle.TimeDuration => TimeSpan.FromMilliseconds(value).ToString("g"),
            DestinyUnlockValueUIStyle.Hidden => string.Empty,
            DestinyUnlockValueUIStyle.Multiplier => "Not implemented, file an issue if you find any",
            DestinyUnlockValueUIStyle.GreenPips => GetPipsString(GreenPip, value),
            DestinyUnlockValueUIStyle.RedPips => GetPipsString(RedPip, value),
            DestinyUnlockValueUIStyle.ExplicitPercentage => $"{value}%",
            DestinyUnlockValueUIStyle.RawFloat => ((float)value / 100).ToString("F2"),
            DestinyUnlockValueUIStyle.LevelAndReward => value.ToString(),
            _ => throw new ArgumentOutOfRangeException(nameof(formattingStyle), formattingStyle, "Failed to format value"),
        };
    }

    private static string GetPipsString(string pipValue, int pipAmount)
    {
        var array = new string[pipAmount];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = pipValue;
        }

        return string.Join(' ', array);
    }

    private static bool ObjectiveIsCompleted(int value, DestinyObjectiveDefinition objectiveDefinition)
    {
        if (objectiveDefinition.IsCountingDownward)
        {
            return value <= objectiveDefinition.CompletionValue;
        }

        return value >= objectiveDefinition.CompletionValue;
    }
}
