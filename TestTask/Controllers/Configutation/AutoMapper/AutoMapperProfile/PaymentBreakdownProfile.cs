using AutoMapper;
using ApiData = Shared.Api.Data.GetPaymentsBreakdown;
using ServiceData = Services.Data.GetPaymentsBreakdown;

namespace TestTask.Controllers.Configutation.AutoMapper.AutoMapperProfile
{
    public class PaymentBreakdownProfile : Profile
    {
        public PaymentBreakdownProfile()
        {
            CreateMap<ApiData.GetPaymentsBreakdownRequest, ServiceData.GetPaymentsBreakdownRequest>();
        }
    }
}