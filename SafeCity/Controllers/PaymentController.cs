﻿using System;
using SafeCity.DTOs;
using SafeCity.Services;
using SafeCity.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SafeCity.Controllers
{
    [Route("api/v1/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILiqPayService _liqPayService;
        public PaymentController(ILiqPayService liqPayService)
        {
            _liqPayService = liqPayService;
        }
        /// <summary>
        /// Generate Data and Signature
        /// https://www.liqpay.ua/documentation/en/data_signature
        /// </summary>
        [HttpPost("data-signature")]
        public IActionResult DataSignature(PaymentRequestDto payment)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            var request = new LiqPayRequest()
            {
                Amount = payment.Amount,
                Description = $"Проект: {payment.ProjectName}",
                OrderId = $"{DateTime.Now.Ticks}-{payment.Email}-{payment.ProjectId}",
                ServerUrl = $"{baseUrl}/api/v1/payment/payment-status",
                ProjectId = payment.ProjectId.ToString(),
                Email = payment.Email
            };

            var result = _liqPayService.GenerateDataAndSignature(request);

            //TODO: store Signature & OrderId in ASP.NET Session (or DB?) to validate it later in /payment-status action

            return Ok(result);
        }

        [HttpPost("payment-status")]
        public IActionResult PaymentStatus([FromForm] string data, [FromForm] string signature)
        {
            //TODO: validate Signature - compare with the one stored in temporary storage
            var liqPayResponse = _liqPayService.DecodeData(data);

            return NoContent();
        }
    }
}
