using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Interfaces
{
  public  interface IPaymentService
    {
        Task<bool> ProcessPaymentAsync(Guid orderId, decimal amount, string paymentMethod);
        Task<string> GetPaymentStatusAsync(Guid orderId);
    }
}
