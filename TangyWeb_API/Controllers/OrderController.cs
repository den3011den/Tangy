﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Tangy_Business.Repository.IRepository;
using Tangy_Models;

namespace TangyWeb_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailSender _emailSender;

        public OrderController(IOrderRepository orderRepository, IEmailSender emailSender)
        {
            _orderRepository = orderRepository;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderRepository.GetAll());
        }

        [HttpGet("{orderHeaderId}")]
        public async Task<IActionResult> Get(int? orderHeaderId)
        {
            if (orderHeaderId == null || orderHeaderId == 0)
            {
                return BadRequest(new ErrorModelDTO() {                    
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var orderHeader = await _orderRepository.Get(orderHeaderId.Value);

            if (orderHeader == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(orderHeader);
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create([FromBody] StripePaymentDTO paymentDTO)
        {
            paymentDTO.Order.OrderHeader.OrderDate = DateTime.Now;
            var result = await _orderRepository.Create(paymentDTO.Order);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("paymentsuccessful")]
        public async Task<IActionResult> paymentsuccessful([FromBody] OrderHeaderDTO orderHeaderDTO)
        {
            var service = new SessionService();            
            var sessionDetails = service.Get(orderHeaderDTO.SessionId);
            if(sessionDetails.PaymentStatus == "paid")
            {
                var result = await _orderRepository.MarkPaymentSuccessful(orderHeaderDTO.Id);
                await _emailSender.SendEmailAsync(orderHeaderDTO.Email, "Подтверждение оплаты заказа",
                    "Создан новый заказ : " + orderHeaderDTO.Id
                    );
                if (result==null)
                {
                    return BadRequest(new ErrorModelDTO()
                    {
                        ErrorMessage = "Не удалось отметить оплату как успешную"
                    });
                }
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
