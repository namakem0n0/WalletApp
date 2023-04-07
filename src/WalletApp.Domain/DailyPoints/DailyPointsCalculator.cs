using WalletApp.Domain.Clock;

namespace WalletApp.Domain.DailyPoints
{
    public class DailyPointsCalculator
{
    private DateTime _seasonStartDate;
    private int _points;
    
    public DailyPointsCalculator(DateTime seasonStartDate)
    {
        _seasonStartDate = seasonStartDate.Date;
        _points = 0;
    }
    
    public int CalculatePoints()
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
    
    public string FormatPoints(int points)
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
