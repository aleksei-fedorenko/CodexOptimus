using FluentAssertions;
using NUnit.Framework;
using Shared.Api.Data.GetPaymentsBreakdown;
using TestTask.Controllers.Validation;
using TestTask.UnitTests.Controllers.Validation.TestCases;

namespace TestTask.UnitTests.Controllers.Validation
{
    [TestFixture]
    public class GetPaymentsBreakdownRequestValidatorTests
    {
        [TestCaseSource(typeof(GetPaymentsBreakdownRequestValidatorTestCases),
            nameof(GetPaymentsBreakdownRequestValidatorTestCases.Validate_PositiveTestCases))]
        public void Validate_PositiveTest(GetPaymentsBreakdownRequest data)
        {
            // Arrange
            var validator = new GetPaymentsBreakdownRequestValidator();

            // Act
            var result = validator.Validate(data);

            // Assert
            result.IsValid.Should().Be(true);
        }

        [TestCaseSource(typeof(GetPaymentsBreakdownRequestValidatorTestCases),
            nameof(GetPaymentsBreakdownRequestValidatorTestCases.Validate_NegativeTestCases))]
        public void Validate_NegativeTest(GetPaymentsBreakdownRequest data)
        {
            // Arrange
            var validator = new GetPaymentsBreakdownRequestValidator();

            // Act
            var result = validator.Validate(data);

            // Assert
            result.IsValid.Should().Be(false);
        }
    }
}