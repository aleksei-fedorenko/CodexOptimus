using Services.Data;
using Services.Data.GetPaymentsBreakdown;

namespace Services.Interfaces
{
    /// <summary>
    /// Service for working with payments breakdown
    /// </summary>
    public interface IPaymentBreakdownService
    {
        /// <summary>
        /// Get a payments breakdown
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Payments breakdown</returns>
        IReadOnlyCollection<PaymentBreakdown> GetPaymentBreakdowns(GetPaymentsBreakdownRequest request);
    }
}