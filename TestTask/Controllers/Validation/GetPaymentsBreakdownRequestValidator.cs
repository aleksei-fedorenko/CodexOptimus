using FluentValidation;
using Shared.Api.Data.GetPaymentsBreakdown;

namespace TestTask.Controllers.Validation
{
    public class GetPaymentsBreakdownRequestValidator : AbstractValidator<GetPaymentsBreakdownRequest>
    {
        public GetPaymentsBreakdownRequestValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .WithMessage("Request is empty.");

            RuleFor(request => request.LoanAmount)
                .GreaterThan(0)
                .WithMessage(nameof(GetPaymentsBreakdownRequest.LoanAmount) + ": must be greater than 0.");

            RuleFor(request => request.LoanStartDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
                .LessThan(request => request.LoanEndDate)
                .WithMessage(nameof(GetPaymentsBreakdownRequest.LoanStartDate)
                    + ": cannot be earlier than the current date and greater than or equal to "
                    + nameof(GetPaymentsBreakdownRequest.LoanEndDate) + ".");

            RuleFor(request => request.LoanEndDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date.AddMonths(1))
                .GreaterThanOrEqualTo(request => request.LoanStartDate.AddMonths(1))
                .WithMessage(nameof(GetPaymentsBreakdownRequest.LoanAmount)
                    + ": cannot be earlier than current date plus one month and earlier than"
                    + $" {nameof(GetPaymentsBreakdownRequest.LoanStartDate)} plus one month.");

            RuleFor(request => request.InterestRate)
                .GreaterThan(0)
                .WithMessage(nameof(GetPaymentsBreakdownRequest.LoanAmount) + " must be greater than 0.");

            RuleFor(request => request.ScheduleType)
                .IsInEnum()
                .WithMessage(nameof(GetPaymentsBreakdownRequest.ScheduleType) + ": invalid value.");

            RuleFor(request => request.PaymentDay)
                .GreaterThanOrEqualTo((byte)1)
                .LessThanOrEqualTo((byte)31)
                .WithMessage(nameof(GetPaymentsBreakdownRequest.PaymentDay) + ": must be greater than 0 and less than 32.");
        }
    }
}