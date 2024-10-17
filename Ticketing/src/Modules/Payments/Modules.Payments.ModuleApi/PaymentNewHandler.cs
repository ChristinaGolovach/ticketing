using MediatR;
using Modules.Payments.Core.Services;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Payments.ModuleApi
{
    public class PaymentNewHandler : IRequestHandler<PaymentNewRequest, Guid>
    {
        private readonly IPaymentService _paymentService;

        public PaymentNewHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<Guid> Handle(PaymentNewRequest request, CancellationToken cancellationToken)
        {
            var payment = await _paymentService.CreatePaymentAsync(request.OrderId, request.Amount, cancellationToken);

            return payment.Id;
        }
    }
}
