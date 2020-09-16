using Stripe;
using StripeCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeCheckout.Payment
{
    public class ProcessPayment
    {
        public static async Task<dynamic> PayAsync(PayModel payModel)
        {
            try
            {
                StripeConfiguration.ApiKey = "your secret key";

                var options = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = payModel.CardNumder,
                        ExpMonth = payModel.Month,
                        ExpYear = payModel.Year,
                        Cvc = payModel.CVC
                    },
                };

                var serviceToken = new TokenService();
                Token stripeToken = await serviceToken.CreateAsync(options);

                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = payModel.Amount,
                    Currency = "usd",
                    Description = "Stripe Test Payment",
                    Source = stripeToken.Id
                };

                var chargeService = new ChargeService();
                Charge charge = await chargeService.CreateAsync(chargeOptions);

                if(charge.Paid)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
