namespace Services.Helpers
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Getting the number of months between two dates
        /// </summary>
        /// <param name="firstDateTime">First date</param>
        /// <param name="secondDateTime">Second date</param>
        /// <returns>Number of months</returns>
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