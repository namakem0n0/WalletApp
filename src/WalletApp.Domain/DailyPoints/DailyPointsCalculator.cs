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

            if (now.Month >= 3 && now.Month <= 5)
            {
                // Spring - first day of March
                _seasonStartDate = new DateTime(now.Year, 3, 1);
            }
            else if (now.Month >= 6 && now.Month <= 8)
            {
                // Summer - first day of June
                _seasonStartDate = new DateTime(now.Year, 6, 1);
            }
            else if (now.Month >= 9 && now.Month <= 11)
            {
                // Autumn - first day of September
                _seasonStartDate = new DateTime(now.Year, 9, 1);
            }
            else if (now.Month == 12)
            {
                // Winter - first day of December
                _seasonStartDate = new DateTime(now.Year, 12, 1);
            }
            else if (now.Month <= 2)
            {
                // Winter - first day of December if next year started
                _seasonStartDate = new DateTime(now.Year - 1, 12, 1);
            }

            _points = 0;
        }

        public static int CalculatePoints(DateTime currentDate)
        {
            var currentDayOfYear = currentDate.DayOfYear;
            var seasonStartDayOfYear = _seasonStartDate.DayOfYear;
            int daysSinceStart;

            if (currentDayOfYear < seasonStartDayOfYear)
                daysSinceStart = currentDayOfYear + DateTime.DaysInMonth(_seasonStartDate.Year, _seasonStartDate.Month);
            else
                daysSinceStart = currentDayOfYear - seasonStartDayOfYear;

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
                var previousPoints = DailyPointsCalculator.CalculatePoints(currentDate.AddDays(-1));
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

