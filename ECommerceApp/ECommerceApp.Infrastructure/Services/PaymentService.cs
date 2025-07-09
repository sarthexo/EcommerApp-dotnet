using ECommerceApp.Application.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.Services
{
   public  class PaymentService:IPaymentService
    {
        // Simulate a payment database using a thread-safe dictionary
        private readonly ConcurrentDictionary<Guid, string> _paymentStatuses = new();

        public Task<string> GetPaymentStatusAsync(Guid orderId)
        {
            if (_paymentStatuses.TryGetValue(orderId,out var status))
            {
                return Task.FromResult(status);
            }
            return Task.FromResult("Not Found");
        }

        public async Task<bool> ProcessPaymentAsync(Guid orderId, decimal amount, string paymentMethod)
        {
            //simulate processing delay
            await Task.Delay(500);

            //Mock success if amount is positive
            if (amount <= 0)
            {
                _paymentStatuses[orderId] = "Failed";
                return false;
            }

            //simulate successful payment
            _paymentStatuses[orderId] = "Success";
            return true;
        }
    }
}
