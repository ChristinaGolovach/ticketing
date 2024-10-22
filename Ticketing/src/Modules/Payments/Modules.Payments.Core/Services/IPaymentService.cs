
using Modules.Payments.Core.Models;

namespace Modules.Payments.Core.Services
{
    public interface IPaymentService
    {
        Task<ViewPaymentDto> CreatePaymentAsync(Guid orderId, double amount, CancellationToken cancellationToken = default);
        Task<ViewPaymentDto> GetPaymentAsync(Guid paymentId, CancellationToken cancellationToken = default);
        Task CompletePaymentAsync(Guid paymentId, CancellationToken cancellationToken = default);
        Task FailedPaymentAsync(Guid paymentId, CancellationToken cancellationToken = default);

    }
}
