using Services.Data;

namespace Shared.Api.Data.GetPaymentsBreakdown
{
    /// <summary>
    /// Payment breakdown response
    /// </summary>
    public class GetPaymentsBreakdownResponse
    {
        /// <summary>
        /// Payment breakdowns
        /// </summary>
        public IReadOnlyCollection<PaymentBreakdown>? PaymentBreakdowns { get; set; }
    }
}