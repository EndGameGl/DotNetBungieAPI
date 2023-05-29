namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Provides utility methods to calculate reset dates
/// </summary>
public interface IDestiny2ResetService
{
    /// <summary>
    ///     Gets the date when next daily reset will occur
    /// </summary>
    /// <returns></returns>
    DateTime GetNextDailyReset();

    /// <summary>
    ///     Gets the date when next weekly reset will occur
    /// </summary>
    /// <param name="day">Weekly reset day</param>
    /// <returns></returns>
    DateTime GetNextWeeklyReset(int day);

    /// <summary>
    ///     Gets the date when next weekly reset will occur
    /// </summary>
    /// <param name="day">Weekly reset day</param>
    /// <returns></returns>
    DateTime GetNextWeeklyReset(DayOfWeek day);

    /// <summary>
    ///     Gets the date when last daily reset occurred
    /// </summary>
    /// <returns></returns>
    DateTime GetPreviousDailyReset();

    /// <summary>
    ///     Gets the date when last weekly reset occurred
    /// </summary>
    /// <param name="day">Weekly reset day</param>
    /// <returns></returns>
    DateTime GetPreviousWeeklyReset(int day);

    /// <summary>
    ///     Gets the date when last weekly reset occurred
    /// </summary>
    /// <param name="day">Weekly reset day</param>
    /// <returns></returns>
    DateTime GetPreviousWeeklyReset(DayOfWeek day);

    /// <summary>
    ///     Gets a <see cref="Task"/> that will be completed on next daily reset if awaited
    /// </summary>
    /// <param name="delay">Optional delay</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task WaitForNextDailyReset(
        TimeSpan delay = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Gets a <see cref="Task"/> that will be completed on next weekly reset if awaited
    /// </summary>
    /// <param name="day">Weekly reset day</param>
    /// <param name="delay">Optional delay</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task WaitForNextWeeklyReset(
        int day,
        TimeSpan delay = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Gets a <see cref="Task"/> that will be completed on next weekly reset if awaited
    /// </summary>
    /// <param name="day">Weekly reset day</param>
    /// <param name="delay">Optional delay</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task WaitForNextWeeklyReset(
        DayOfWeek day,
        TimeSpan delay = default,
        CancellationToken cancellationToken = default
    );
}
