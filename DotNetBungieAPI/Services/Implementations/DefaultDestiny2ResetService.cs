using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefaultDestiny2ResetService : IDestiny2ResetService
{
    private readonly TimeSpan _singleDay = TimeSpan.FromDays(1);
    private readonly TimeSpan _sevenDays = TimeSpan.FromDays(7);

    private const int DailyResetHour = 17;

    public DefaultDestiny2ResetService() { }

    private static int ConvertDayOfWeekToInt(DayOfWeek dayOfWeek)
    {
        return dayOfWeek switch
        {
            DayOfWeek.Sunday => 7,
            DayOfWeek.Monday => 1,
            DayOfWeek.Tuesday => 2,
            DayOfWeek.Wednesday => 3,
            DayOfWeek.Thursday => 4,
            DayOfWeek.Friday => 5,
            DayOfWeek.Saturday => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null)
        };
    }

    public DateTime GetNextDailyReset()
    {
        var currentDate = DateTime.UtcNow;
        var dateInQuestion = new DateTime(
            currentDate.Year,
            currentDate.Month,
            currentDate.Day,
            DailyResetHour,
            0,
            0
        );
        return dateInQuestion < currentDate ? dateInQuestion.AddDays(1) : dateInQuestion;
    }

    public DateTime GetNextWeeklyReset(int day)
    {
        var currentDate = DateTime.UtcNow;

        var dateInQuestion = new DateTime(
            currentDate.Year,
            currentDate.Month,
            currentDate.Day,
            DailyResetHour,
            0,
            0
        );

        var currentDay = ConvertDayOfWeekToInt(dateInQuestion.DayOfWeek);

        if (currentDay < day)
        {
            dateInQuestion = dateInQuestion.AddDays(day - currentDay);
        }
        else if (currentDay > day)
        {
            dateInQuestion = dateInQuestion.AddDays(7 - (currentDay - day));
        }

        return dateInQuestion;
    }

    public DateTime GetNextWeeklyReset(DayOfWeek day)
    {
        var dayNumber = ConvertDayOfWeekToInt(day);
        return GetNextWeeklyReset(dayNumber);
    }

    public DateTime GetPreviousDailyReset()
    {
        return GetNextDailyReset().Subtract(_singleDay);
    }

    public DateTime GetPreviousWeeklyReset(int day)
    {
        return GetNextWeeklyReset(day).Subtract(_sevenDays);
    }

    public DateTime GetPreviousWeeklyReset(DayOfWeek day)
    {
        return GetNextWeeklyReset(day).Subtract(_sevenDays);
    }

    public Task WaitForNextDailyReset(
        TimeSpan delay = default,
        CancellationToken cancellationToken = default
    )
    {
        return Task.Delay((GetNextDailyReset() - DateTime.UtcNow).Add(delay), cancellationToken);
    }

    public Task WaitForNextWeeklyReset(
        int day,
        TimeSpan delay = default,
        CancellationToken cancellationToken = default
    )
    {
        return Task.Delay(
            (GetNextWeeklyReset(day) - DateTime.UtcNow).Add(delay),
            cancellationToken
        );
    }

    public Task WaitForNextWeeklyReset(
        DayOfWeek day,
        TimeSpan delay = default,
        CancellationToken cancellationToken = default
    )
    {
        return Task.Delay(
            (GetNextWeeklyReset(day) - DateTime.UtcNow).Add(delay),
            cancellationToken
        );
    }
}
