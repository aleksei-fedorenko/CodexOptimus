using NUnit.Framework;
using Services.Data.GetPaymentsBreakdown;
using Services.Helpers;

namespace Services.UnitTests.TestCases
{
    public static class PaymentBreakdownServiceTestCases
    {
        public static IEnumerable<TestCaseData> GetPaymentBreakdowns_Annuity_PositiveTestCases()
        {
            return new List<TestCaseData>
            {
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 120000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.AddMonths(6).Date,
                        InterestRate = 18,
                        ScheduleType = Data.Enum.LoanRepaymentScheduleType.Annuity,
                    },
                    new List<Data.PaymentBreakdown>
                    {
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19263.03,
                            LoanInterestPaymentAmount = 1800.00,
                            LoanBalance = 100736.97,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                1,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19551.97,
                            LoanInterestPaymentAmount = 1511.05,
                            LoanBalance = 81185.00,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                2,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19845.25,
                            LoanInterestPaymentAmount = 1217.78,
                            LoanBalance = 61339.75,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                3,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20142.93,
                            LoanInterestPaymentAmount = 920.10,
                            LoanBalance = 41196.82,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                4,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20445.07,
                            LoanInterestPaymentAmount = 617.95,
                            LoanBalance = 20751.75,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                5,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20751.75,
                            LoanInterestPaymentAmount = 311.28,
                            LoanBalance = 0,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                6,
                                6),
                        },
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 120000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.AddMonths(6).Date,
                        InterestRate = 18,
                        ScheduleType = Data.Enum.LoanRepaymentScheduleType.Annuity,
                        PaymentDay = 31,
                    },
                    new List<Data.PaymentBreakdown>
                    {
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19263.03,
                            LoanInterestPaymentAmount = 1800.00,
                            LoanBalance = 100736.97,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                31,
                                1,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19551.97,
                            LoanInterestPaymentAmount = 1511.05,
                            LoanBalance = 81185.00,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                31,
                                2,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19845.25,
                            LoanInterestPaymentAmount = 1217.78,
                            LoanBalance = 61339.75,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                31,
                                3,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20142.93,
                            LoanInterestPaymentAmount = 920.10,
                            LoanBalance = 41196.82,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                31,
                                4,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20445.07,
                            LoanInterestPaymentAmount = 617.95,
                            LoanBalance = 20751.75,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                31,
                                5,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20751.75,
                            LoanInterestPaymentAmount = 311.28,
                            LoanBalance = 0,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                31,
                                6,
                                6),
                        },
                    })
            };
        }

        public static IEnumerable<TestCaseData> GetPaymentBreakdowns_Annuity_NegativeTestCases()
        {
            return new List<TestCaseData>
            {
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 120000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.AddMonths(6).Date,
                        InterestRate = 18,
                        ScheduleType = Data.Enum.LoanRepaymentScheduleType.Annuity,
                    },
                    new List<Data.PaymentBreakdown>
                    {
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19263.03,
                            LoanInterestPaymentAmount = 1800.00,
                            LoanBalance = 110736.97,
                            PaymentDate = DateTime.Now.Date.AddMonths(1).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19551.97,
                            LoanInterestPaymentAmount = 1511.05,
                            LoanBalance = 82185.00,
                            PaymentDate = DateTime.Now.Date.AddMonths(2).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 19845.25,
                            LoanInterestPaymentAmount = 1217.78,
                            LoanBalance = 64339.75,
                            PaymentDate = DateTime.Now.Date.AddMonths(3).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20142.93,
                            LoanInterestPaymentAmount = 920.10,
                            LoanBalance = 44196.82,
                            PaymentDate = DateTime.Now.Date.AddMonths(4).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20445.07,
                            LoanInterestPaymentAmount = 617.95,
                            LoanBalance = 26751.75,
                            PaymentDate = DateTime.Now.Date.AddMonths(5).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20751.75,
                            LoanInterestPaymentAmount = 311.28,
                            LoanBalance = 0,
                            PaymentDate = DateTime.Now.Date.AddMonths(6).Date,
                        },
                    })
            };
        }

        public static IEnumerable<TestCaseData> GetPaymentBreakdowns_Differentiated_PositiveTestCases()
        {
            return new List<TestCaseData>
            {
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 120000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.AddMonths(6).Date,
                        InterestRate = 18,
                        ScheduleType = Data.Enum.LoanRepaymentScheduleType.Differentiated,
                    },
                    new List<Data.PaymentBreakdown>
                    {
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1800,
                            LoanBalance = 100000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                1,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1500,
                            LoanBalance = 80000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                2,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1200,
                            LoanBalance = 60000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                3,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 900,
                            LoanBalance = 40000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                4,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 600,
                            LoanBalance = 20000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                5,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 300,
                            LoanBalance = 0,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                null,
                                6,
                                6),
                        },
                    }),
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 120000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.AddMonths(6).Date,
                        InterestRate = 18,
                        ScheduleType = Data.Enum.LoanRepaymentScheduleType.Differentiated,
                        PaymentDay = 29,
                    },
                    new List<Data.PaymentBreakdown>
                    {
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1800,
                            LoanBalance = 100000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                29,
                                1,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1500,
                            LoanBalance = 80000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                29,
                                2,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1200,
                            LoanBalance = 60000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                29,
                                3,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 900,
                            LoanBalance = 40000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                29,
                                4,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 600,
                            LoanBalance = 20000,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                29,
                                5,
                                6),
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 300,
                            LoanBalance = 0,
                            PaymentDate = PaymentBreakdownHelper.GetPaymentDate(
                                DateTime.Now.Date,
                                DateTime.Now.AddMonths(6).Date,
                                29,
                                6,
                                6),
                        },
                    })
            };
        }

        public static IEnumerable<TestCaseData> GetPaymentBreakdowns_Differentiated_NegativeTestCases()
        {
            return new List<TestCaseData>
            {
                new TestCaseData(
                    new GetPaymentsBreakdownRequest
                    {
                        LoanAmount = 120000,
                        LoanStartDate = DateTime.Now.Date,
                        LoanEndDate = DateTime.Now.AddMonths(6).Date,
                        InterestRate = 18,
                        ScheduleType = Data.Enum.LoanRepaymentScheduleType.Differentiated,
                    },
                    new List<Data.PaymentBreakdown>
                    {
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1820,
                            LoanBalance = 100000,
                            PaymentDate = DateTime.Now.Date.AddMonths(1).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1530,
                            LoanBalance = 80000,
                            PaymentDate = DateTime.Now.Date.AddMonths(2).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 1250,
                            LoanBalance = 60000,
                            PaymentDate = DateTime.Now.Date.AddMonths(3).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 200,
                            LoanBalance = 40000,
                            PaymentDate = DateTime.Now.Date.AddMonths(4).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 700,
                            LoanBalance = 20000,
                            PaymentDate = DateTime.Now.Date.AddMonths(5).Date,
                        },
                        new Data.PaymentBreakdown
                        {
                            LoanPaymentAmount = 20000,
                            LoanInterestPaymentAmount = 200,
                            LoanBalance = 0,
                            PaymentDate = DateTime.Now.Date.AddMonths(6).Date,
                        },
                    })
            };
        }
    }
}