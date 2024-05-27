using Application.DTOs;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class AddPayment:IRequest<object>
    {
        public PaymentDTO? paymentDTO {  get; set; }
    }

    public class AddPaymentHandler : IRequestHandler<AddPayment, object>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStripeService _stripeService;

        public AddPaymentHandler(IApplicationDbContext context, IMapper mapper, IStripeService stripeService)
        {
            _context = context;
            _mapper = mapper;
            _stripeService = stripeService;
        }

        //public async Task<object> Handle(AddPayment request, CancellationToken cancellationToken)
        //{
        //    var paymentIntent = await _stripeService.CreatePaymentIntent(request.paymentDTO.Amount, request.paymentDTO.Currency);
        //    var map = _mapper.Map<PaymentGateway>(request.paymentDTO);
        //    var payment = new PaymentGateway
        //    {
        //        Amount = request.paymentDTO.Amount,
        //        Currency = request.paymentDTO.Currency,
        //    };
        //    _context.PaymentGateways.Add(payment);
        //    await _context.SaveChangesAsync();

        //    return ("Payment Successfull");
        //}

        public async Task<object> Handle(AddPayment request, CancellationToken cancellationToken)
        {
            // Create a payment intent using Stripe
            var paymentIntent = await _stripeService.CreatePaymentIntent(request.paymentDTO.Amount, request.paymentDTO.Currency);

            var payment = _mapper.Map<PaymentGateway>(request.paymentDTO);

            _context.PaymentGateways.Add(payment);
            await _context.SaveChangesAsync();

            return new
            {
                Message = "Payment Successful",
                Amount = payment.Amount,
                Currency = payment.Currency
            };
        }


    }




}
