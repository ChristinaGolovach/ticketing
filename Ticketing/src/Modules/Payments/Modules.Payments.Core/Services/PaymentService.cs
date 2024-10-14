using MediatR;
using Modules.Payments.Core.Models;
using Modules.Payments.Data;
using Modules.Payments.Data.Entities;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Data.Repository;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Payments.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMediator _mediator;
        private IRepository<Payment, PaymentsDBContext> _repository;

        public PaymentService(IRepository<Payment, PaymentsDBContext> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<ViewPaymentDto> GetPaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task CompletePaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            var payment = await GetByIdAsync(paymentId, cancellationToken);

            payment.Status = PaymentStatus.Paid;
            _repository.Update(payment);

            await _mediator.Send(new PaymentCompleteRequest
            { 
                PaymentId = paymentId,
                OrderId = payment.OrderId,
            },
            cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task FailedPaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            var payment = await GetByIdAsync(paymentId, cancellationToken);

            payment.Status = PaymentStatus.Failed;
            _repository.Update(payment);

            await _mediator.Send(new PaymentFailedRequest
            {
                PaymentId = paymentId,
                OrderId = payment.OrderId,
            }, 
            cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);
        }

        private async Task<Payment> GetByIdAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            var payment = await _repository.GetByIdAsync(paymentId, cancellationToken);
            if (payment == null)
            {
                throw new ResourceNotFoundException($"Payment {paymentId} is not found.");
            }

            return payment;
        }
    }
}
