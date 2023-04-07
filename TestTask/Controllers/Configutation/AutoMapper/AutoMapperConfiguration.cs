using TestTask.Controllers.Configutation.AutoMapper.AutoMapperProfile;

namespace TestTask.Controllers.Configutation.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PaymentBreakdownProfile));
        }
    }
}