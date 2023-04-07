namespace Services.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetTotalMonthsFrom(this DateTime firstDateTime, DateTime secondDateTime)
        {
            var earlyDate = (firstDateTime > secondDateTime)
                ? secondDateTime.Date
                : firstDateTime.Date;
            var lateDate = (firstDateTime > secondDateTime)
                ? firstDateTime.Date
                : secondDateTime.Date;

            int monthsDiff = 1;
            while (earlyDate.AddMonths(monthsDiff) <= lateDate)
            {
                monthsDiff++;
            }

            return monthsDiff - 1;
        }
    }
}