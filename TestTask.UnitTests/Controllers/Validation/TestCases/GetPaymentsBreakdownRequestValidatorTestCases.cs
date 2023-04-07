using NUnit.Framework;
using Shared.Api.Data.GetPaymentsBreakdown;

namespace TestTask.UnitTests.Controllers.Validation.TestCases
{
    public static class GetPaymentsBreakdownRequestValidatorTestCases
    {
        public static IEnumerable<TestCaseData> Validate_PositiveTestCases()
        {
            return new List<TestCaseData>
            {
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Annuity,
                        InterestRate = 18,
                        PaymentDay = 1,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 300000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 100,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 300000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 200,
                        PaymentDay = 31,
                    }),
            };
        }

        public static IEnumerable<TestCaseData> Validate_NegativeTestCases()
        {
            return new List<TestCaseData>
            {
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 0,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Annuity,
                        InterestRate = 18,
                        PaymentDay = 1,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = -1,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 100,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date.AddMonths(-1),
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 100,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date,
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 100,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddDays(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 100,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date.AddMonths(6),
                        LoanEndDate = DateTime.Now.Date,
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 100,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = 0,
                        InterestRate = 100,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 0,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = -1,
                        PaymentDay = 31,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 100,
                        PaymentDay = 0,
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 100000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.Date.AddMonths(6),
                        ScheduleType = Services.Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        InterestRate = 100,
                        PaymentDay = 32,
                    }),
            };
        }
    }
}