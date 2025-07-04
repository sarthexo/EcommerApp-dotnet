using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Payments.Queries
{
   public  record GetPaymentStatusQuery(Guid OrderId):IRequest<string>;
    
}
