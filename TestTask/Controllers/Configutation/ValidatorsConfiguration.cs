using FluentValidation;
using TestTask.Controllers.Validation;

namespace TestTask.Controllers.Configutation
{
    public static class ValidatorsConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<GetPaymentsBreakdownRequestValidator>();
        }
    }
}