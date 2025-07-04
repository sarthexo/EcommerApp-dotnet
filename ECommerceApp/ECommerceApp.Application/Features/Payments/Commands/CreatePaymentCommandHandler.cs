using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Payments.Commands
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
    {
        private readonly IPaymentService _paymentService;

        public CreatePaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;   
        }
        public async Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            return await _paymentService.ProcessPaymentAsync(request.OrderId, request.Amount, request.PaymentMethod);
        }
    }
}
