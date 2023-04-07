using FluentAssertions;
using NUnit.Framework;
using Services.Data.GetPaymentsBreakdown;
using Services.Interfaces;
using Services.UnitTests.TestCases;

namespace Services.UnitTests
{
    [TestFixture]
    public class PaymentBreakdownServiceTests
    {
        private IPaymentBreakdownService _paymentBreakdownService;

        [SetUp]
        public void SetUp()
        {
            _paymentBreakdownService = new PaymentBreakdownService();
        }

        [TestCaseSource(typeof(PaymentBreakdownServiceTestCases),
            nameof(PaymentBreakdownServiceTestCases.GetPaymentBreakdowns_Annuity_PositiveTestCases))]
        public void GetPaymentBreakdowns_Annuity_PositiveTest(
            GetPaymentsBreakdownRequest request,
            List<Data.PaymentBreakdown> expectedResult)
        {
            // Act
            var result = _paymentBreakdownService.GetPaymentBreakdowns(request);

            // Assert
            result.Should().NotBeEmpty().And.BeEquivalentTo(expectedResult);
            result.Last().LoanBalance.Should().Be(0);
            result.Sum(element => element.LoanPaymentAmount).Should().Be(request.LoanAmount);
            result.Select(element => (element.PaymentDate.Year, element.PaymentDate.Month))
                .Should()
                .OnlyHaveUniqueItems();
        }

        [TestCaseSource(typeof(PaymentBreakdownServiceTestCases),
            nameof(PaymentBreakdownServiceTestCases.GetPaymentBreakdowns_Annuity_NegativeTestCases))]
        public void GetPaymentBreakdowns_Annuity_NegativeTest(
            GetPaymentsBreakdownRequest request,
            List<Data.PaymentBreakdown> expectedResult)
        {
            // Act
            var result = _paymentBreakdownService.GetPaymentBreakdowns(request);

            // Assert
            result.Should().NotBeEquivalentTo(expectedResult);
        }

        [TestCaseSource(typeof(PaymentBreakdownServiceTestCases),
            nameof(PaymentBreakdownServiceTestCases.GetPaymentBreakdowns_Differentiated_PositiveTestCases))]
        public void GetPaymentBreakdowns_Differentiated_PositiveTest(
            GetPaymentsBreakdownRequest request,
            List<Data.PaymentBreakdown> expectedResult)
        {
            // Act
            var result = _paymentBreakdownService.GetPaymentBreakdowns(request);

            // Assert
            result.Should().NotBeEmpty().And.BeEquivalentTo(expectedResult);
            result.Last().LoanBalance.Should().Be(0);
            result.Sum(element => element.LoanPaymentAmount).Should().Be(request.LoanAmount);
            result.Select(element => (element.PaymentDate.Year, element.PaymentDate.Month))
                .Should()
                .OnlyHaveUniqueItems();
        }

        [TestCaseSource(typeof(PaymentBreakdownServiceTestCases),
            nameof(PaymentBreakdownServiceTestCases.GetPaymentBreakdowns_Differentiated_NegativeTestCases))]
        public void GetPaymentBreakdowns_Differentiated_NegativeTest(
            GetPaymentsBreakdownRequest request,
            List<Data.PaymentBreakdown> expectedResult)
        {
            // Act
            var result = _paymentBreakdownService.GetPaymentBreakdowns(request);

            // Assert
            result.Should().NotBeEquivalentTo(expectedResult);
        }
    }
}