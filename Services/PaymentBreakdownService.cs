﻿using Services.Data;
using Services.Data.GetPaymentsBreakdown;
using Services.Helpers;
using Services.Interfaces;

namespace Services
{
    public class PaymentBreakdownService : IPaymentBreakdownService
    {
        public IReadOnlyCollection<PaymentBreakdown> GetPaymentBreakdowns(GetPaymentsBreakdownRequest request)
        {
            request.ThrowIfNull(nameof(request));

            return request.ScheduleType switch
            {
                Data.Enum.LoanRepaymentScheduleType.Annuity =>
                    CombinePaymentBreakdownsForAnnuityScheduleType(request),
                Data.Enum.LoanRepaymentScheduleType.Differentiated =>
                    CombinePaymentBreakdownsForDifferentiatedScheduleType(request),
                _ => throw new NotImplementedException($"{nameof(GetPaymentBreakdowns)} does not support"
                    + $" {nameof(request.ScheduleType)} with value {request.ScheduleType}"),
            };
        }

        #region Private methods

        private static IReadOnlyCollection<PaymentBreakdown> CombinePaymentBreakdownsForAnnuityScheduleType(
            GetPaymentsBreakdownRequest request)
        {
            var numberOfMonths = request.LoanEndDate.GetTotalMonthsFrom(request.LoanStartDate);
            var monthlyRate = request.InterestRate / 12 / 100;
            var annuityCoeff = Math.Pow(1 + monthlyRate, numberOfMonths);
            var monthlyLoanPayment = request.LoanAmount * (monthlyRate * annuityCoeff / (annuityCoeff - 1));

            var loanBalance = request.LoanAmount;
            return Enumerable.Range(1, numberOfMonths)
                .Select(numberOfMonth =>
                {
                    var overpaymentPerMonth = loanBalance * monthlyRate;
                    loanBalance -= monthlyLoanPayment - overpaymentPerMonth;

                    return new PaymentBreakdown
                    {
                        PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                            request.LoanStartDate,
                            request.LoanEndDate,
                            request.PaymentDay,
                            numberOfMonth,
                            numberOfMonths),
                        LoanBalance = Math.Round(loanBalance, 2),
                        LoanInterestPaymentAmount = Math.Round(overpaymentPerMonth, 2),
                        LoanPaymentAmount = Math.Round(monthlyLoanPayment - overpaymentPerMonth, 2),
                    };
                })
                .ToArray();
        }

        private static IReadOnlyCollection<PaymentBreakdown> CombinePaymentBreakdownsForDifferentiatedScheduleType(
            GetPaymentsBreakdownRequest request)
        {
            var numberOfMonths = request.LoanEndDate.GetTotalMonthsFrom(request.LoanStartDate);
            var monthlyLoanPayment = Math.Round(request.LoanAmount / numberOfMonths, 2);
            var loanInterestPaymentRate = request.InterestRate / 100 / 12;

            var loanBalance = request.LoanAmount;
            return Enumerable.Range(1, numberOfMonths)
                .Select(numberOfMonth =>
                {
                    var result = new PaymentBreakdown
                    {
                        PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                            request.LoanStartDate,
                            request.LoanEndDate,
                            request.PaymentDay,
                            numberOfMonth,
                            numberOfMonths),
                        LoanBalance = Math.Round(loanBalance - monthlyLoanPayment, 2),
                        LoanInterestPaymentAmount = Math.Round(loanBalance * loanInterestPaymentRate, 2),
                        LoanPaymentAmount = monthlyLoanPayment,
                    };

                    loanBalance -= monthlyLoanPayment;

                    return result;
                })
                .ToArray();
        }

        #endregion Private methods
    }
}