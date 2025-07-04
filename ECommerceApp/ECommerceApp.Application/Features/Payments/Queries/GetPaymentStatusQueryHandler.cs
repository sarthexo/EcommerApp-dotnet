using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Payments.Queries
{
    public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusQuery, string>
    {
        private readonly IPaymentService _paymentService;

        public GetPaymentStatusQueryHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;   
        }
        public async Task<string> Handle(GetPaymentStatusQuery request, CancellationToken cancellationToken)
        {
            return await _paymentService.GetPaymentStatusAsync(request.OrderId);
        }
    }
}
