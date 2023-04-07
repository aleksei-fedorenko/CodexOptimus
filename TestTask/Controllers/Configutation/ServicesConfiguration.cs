using Services;
using Services.Interfaces;

namespace TestTask.Controllers.Configutation
{
    public static class ServicesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IPaymentBreakdownService, PaymentBreakdownService>();
        }
    }
}