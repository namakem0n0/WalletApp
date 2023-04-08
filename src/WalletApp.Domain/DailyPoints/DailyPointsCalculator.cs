using WalletApp.Domain.Clock;

namespace WalletApp.Domain.DailyPoints
{
    public static class DailyPointsCalculator
{
    private static DateTime _seasonStartDate;
    private static int _points;
    
    static DailyPointsCalculator()
    {
        DateTime now = SystemClock.Now;

        if (now.Month >= 1 && now.Month <= 3)
        {
            // Spring - first day of March
            _seasonStartDate = new DateTime(now.Year, 3, 1);
        }
        else if (now.Month >= 4 && now.Month <= 6)
        {
            // Summer - first day of June
            _seasonStartDate = new DateTime(now.Year, 6, 1);
        }
        else if (now.Month >= 7 && now.Month <= 9)
        {
            // Autumn - first day of September
            _seasonStartDate = new DateTime(now.Year, 9, 1);
        }
        else
        {
            // Winter - first day of December
            _seasonStartDate = new DateTime(now.Year, 12, 1);
        }
        _points = 0;
    }
    
    public static int CalculatePoints()
    {
        var currentDayOfYear = SystemClock.Now.DayOfYear;
        var startDayOfYear = _seasonStartDate.DayOfYear;
        var daysSinceStart = currentDayOfYear - startDayOfYear;

        if (daysSinceStart == 0)
        {
            _points = 2;
        }
        else if (daysSinceStart == 1)
        {
            _points = 3;
        }
        else
        {
            var previousPoints = _points;
            var previousDayPoints = previousPoints * 0.6;
            var previousDayRoundedPoints = Math.Round(previousDayPoints, 0, MidpointRounding.AwayFromZero);

            _points = (int)Math.Round(previousPoints + previousDayRoundedPoints, 0, MidpointRounding.AwayFromZero);
        }

        return _points;
    }
    
    public static string FormatPoints(int points)
    {
        if (points >= 1000)
        {
            return (points / 1000) + "K";
        }
        else
        {
            return points.ToString();
        }
    }
}
}
