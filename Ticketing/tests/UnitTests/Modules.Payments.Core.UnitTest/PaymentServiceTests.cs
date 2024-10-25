using AutoMapper;
using MediatR;
using MockQueryable;
using Modules.Payments.Core.Models;
using Modules.Payments.Core.Services;
using Modules.Payments.Core.UnitTest.FakeData;
using Modules.Payments.Data.Entities;
using Modules.Payments.Infrastructure.Data;
using Moq;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Data;
using Xunit;

namespace Modules.Payments.Core.UnitTest
{
    public class PaymentServiceTests
    {
        private readonly Mock<IRepository<Payment, PaymentsDBContext>> _repositoryMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IQueryable<Payment> _payments;

        public PaymentServiceTests()
        {
            _payments = FakePayment.CreateFakePayments();

            _repositoryMock = new Mock<IRepository<Payment, PaymentsDBContext>>();
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();

            ConfigureMocks();
        }

        [Theory]
        [InlineData("87b6b120-63c0-4e8e-93f8-d827be176a5e")]
        [InlineData("7796e9a7-4e0a-4a2a-957e-a4f6f61b2f7c")]
        public async Task GetPayment_Should_ThrowException_WhenPaymentIsNotFound(string paymentGuidId)
        {
            // Arrange
            var paymentId = new Guid(paymentGuidId);

            var sut = new PaymentService(_repositoryMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act - Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.GetPaymentAsync(paymentId));
        }

        [Theory]
        [InlineData("87b6b120-63c0-4e8e-93f8-d827be176a5e", 256.36)]
        [InlineData("7796e9a7-4e0a-4a2a-957e-a4f6f61b2f7c", 1546.3)]
        public async Task CreatePayment_Should_CreatePayment(string orderGuidId, double amount)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new PaymentService(_repositoryMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act
            var newPayment = await sut.CreatePaymentAsync(orderId, amount);

            // Assert
            Assert.NotNull(newPayment);
            Assert.True(newPayment.Status == PaymentStatus.InProcess);
            Assert.Equal(amount, newPayment.Amount);
        }

        private void ConfigureMocks()
        {
            _repositoryMock.Setup(r => r.Query()).Returns(_payments.BuildMock());

            _repositoryMock.Setup(r => r.GetByIdAsync(It.Is<Guid>(i => i != Guid.Empty), default))
                .Returns((Guid id, CancellationToken token) => Task.FromResult(_payments.FirstOrDefault(a => a.Id == id)));

            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Payment>(), default))
                .Callback((Payment payment, CancellationToken token) => _payments.ToList().Add(payment));

            _mapperMock.Setup(m => m.Map<ViewPaymentDto>(It.IsAny<Payment>()))
                .Returns((Payment payment) => new ViewPaymentDto
                {
                    Id = payment.Id,
                    Status = payment.Status,
                    Amount = payment.Amount
                });
        }
    }
}
