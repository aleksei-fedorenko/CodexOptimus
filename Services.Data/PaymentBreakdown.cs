namespace Services.Data
{
    /// <summary>
    /// Payment breakdown
    /// </summary>
    [Serializable]
    public class PaymentBreakdown
    {
        /// <summary>
        /// Payment date
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Loan payment amount
        /// </summary>
        public double LoanPaymentAmount { get; set; }

        /// <summary>
        /// Loan interest payment amount
        /// </summary>
        public double LoanInterestPaymentAmount { get; set; }

        /// <summary>
        /// Loan balance
        /// </summary>
        public double LoanBalance { get; set; }
    }
}