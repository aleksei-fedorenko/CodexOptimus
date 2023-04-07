using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Shared.Api.Data.GetPaymentsBreakdown;
using System.Net;
using TestTask.Controllers.Validation;
using ServiceData = Services.Data;

namespace TestTask.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PaymentBreakdownController : ControllerBase
    {
        private readonly IPaymentBreakdownService _paymentBreakdownService;
        private readonly IMapper _mapper;

        public PaymentBreakdownController(
            IPaymentBreakdownService paymentBreakdownService,
            IMapper mapper)
        {
            _paymentBreakdownService = paymentBreakdownService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a payments breakdown
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Payments breakdown</returns>
        [HttpPost, ProducesResponseType(typeof(GetPaymentsBreakdownResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetPaymentsBreakdown([FromBody] GetPaymentsBreakdownRequest request)
        {
            request.LoanEndDate = request.LoanEndDate.Date;
            request.LoanStartDate = request.LoanStartDate.Date;

            new GetPaymentsBreakdownRequestValidator().ValidateAndThrow(request);

            var serviceRequest = _mapper.Map<ServiceData.GetPaymentsBreakdown.GetPaymentsBreakdownRequest>(request);

            var result = new GetPaymentsBreakdownResponse
            {
                PaymentBreakdowns = _paymentBreakdownService.GetPaymentBreakdowns(serviceRequest),
            };

            return Ok(result);
        }
    }
}