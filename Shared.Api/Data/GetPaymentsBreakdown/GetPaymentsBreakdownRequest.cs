using Services.Data.Enum;

namespace Shared.Api.Data.GetPaymentsBreakdown
{
    /// <summary>
    /// Request for payment breakdown
    /// </summary>
    public class GetPaymentsBreakdownRequest
    {
        /// <summary>
        /// Amount of loan
        /// </summary>
        public double LoanAmount { get; set; }

        /// <summary>
        /// Loan start date
        /// </summary>
        public DateTime LoanStartDate { get; set; }

        /// <summary>
        /// Loan end date
        /// </summary>
        public DateTime LoanEndDate { get; set; }

        /// <summary>
        /// Interest rate
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// Schedule type
        /// </summary>
        public LoanRepaymentScheduleType ScheduleType { get; set; }

        /// <summary>
        /// Payment day
        /// </summary>
        public byte? PaymentDay { get; set; }
    }
}