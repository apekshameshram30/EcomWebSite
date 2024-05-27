using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IStripeService
    {
        Task<PaymentIntent> CreatePaymentIntent(decimal amount, string currency);
    }
}
