using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Shared.Api.Data.GetPaymentsBreakdown;
using System.Net;
using System.Text.Json;
using TestTask.Controllers.Validation;
using ServiceData = Services.Data;

namespace TestTask.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PaymentBreakdownController : ControllerBase
    {
        private readonly IPaymentBreakdownService _paymentBreakdownService;
        private readonly ILogger<PaymentBreakdownController> _logger;
        private readonly IMapper _mapper;

        public PaymentBreakdownController(
            IPaymentBreakdownService paymentBreakdownService,
            IMapper mapper,
            ILogger<PaymentBreakdownController> logger)
        {
            _paymentBreakdownService = paymentBreakdownService;
            _logger = logger;
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
            _logger.LogInformation("GetPaymentsBreakdown request: {0}", JsonSerializer.Serialize(request));

            new GetPaymentsBreakdownRequestValidator().ValidateAndThrow(request);

            request.LoanEndDate = request.LoanEndDate.Date;
            request.LoanStartDate = request.LoanStartDate.Date;

            var serviceRequest = _mapper.Map<ServiceData.GetPaymentsBreakdown.GetPaymentsBreakdownRequest>(request);

            var result = new GetPaymentsBreakdownResponse
            {
                PaymentBreakdowns = _paymentBreakdownService.GetPaymentBreakdowns(serviceRequest),
            };

            _logger.LogInformation("GetPaymentsBreakdown response: {0}", JsonSerializer.Serialize(result));

            return Ok(result);
        }
    }
}