using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Payments.Commands
{
   public record CreatePaymentCommand(Guid OrderId,decimal Amount,string PaymentMethod):IRequest<bool>;
    
}
