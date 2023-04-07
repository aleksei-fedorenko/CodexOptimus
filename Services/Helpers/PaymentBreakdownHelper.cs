namespace Services.Helpers
{
    public static class PaymentBreakdownHelper
    {
        public static DateTime GetPaymentDate(
            DateTime loanStartDate,
            int? paymentDay,
            int numberOfMonth)
        {
            var paymentDate = loanStartDate.AddMonths(numberOfMonth).Date;

            if (paymentDay.HasValue)
            {
                var daysInMonth = DateTime.DaysInMonth(paymentDate.Year, paymentDate.Month);

                paymentDate = paymentDay <= daysInMonth
                    ? new DateTime(paymentDate.Year, paymentDate.Month, paymentDay.Value)
                    : new DateTime(paymentDate.Year, paymentDate.Month, daysInMonth);
            }

            var normalizedPaymentDate = paymentDate.DayOfWeek switch
            {
                DayOfWeek.Saturday => paymentDate.AddDays(2),
                DayOfWeek.Sunday => paymentDate.AddDays(1),
                _ => paymentDate,
            };

            paymentDate = paymentDate.Year == normalizedPaymentDate.Year
                    && paymentDate.Month == normalizedPaymentDate.Month
                ? normalizedPaymentDate
                : paymentDate.DayOfWeek switch
                {
                    DayOfWeek.Saturday => paymentDate.AddDays(-1),
                    DayOfWeek.Sunday => paymentDate.AddDays(-2),
                    _ => paymentDate,
                };

            return paymentDate;
        }
    }
}