using AutoMapper;
using MediatR;
using Modules.Payments.Core.Models;
using Modules.Payments.Data.Entities;
using Modules.Payments.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Data;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Payments.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment, PaymentsDBContext> _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentService(IRepository<Payment, PaymentsDBContext> repository, 
            IMediator mediator,
            IMapper mapper)
        {
            _repository = repository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ViewPaymentDto> GetPaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            var payment = await GetByIdAsync(paymentId, cancellationToken);

            var paymentDto = _mapper.Map<ViewPaymentDto>(payment);

            return paymentDto;
        }

        public async Task<ViewPaymentDto> CreatePaymentAsync(Guid orderId, double amount, CancellationToken cancellationToken = default)
        {
            var payment = new Payment { Amount = amount, OrderId = orderId, Status = PaymentStatus.InProcess };

            await _repository.AddAsync(payment, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

           var paymentDto = _mapper.Map<ViewPaymentDto>(payment);

            return paymentDto;
        }

        public async Task CompletePaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            var payment = await GetByIdAsync(paymentId, cancellationToken);

            payment.Status = PaymentStatus.Paid;
            _repository.Update(payment);

            await _mediator.Send(new OrderCompleteRequest
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

            await _mediator.Send(new OrderFailedRequest
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
