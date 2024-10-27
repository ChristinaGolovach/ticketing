using Modules.Payments.Data.Entities;

namespace Modules.Payments.Core.UnitTest.FakeData
{
    public class FakePayment
    {
        public static IQueryable<Payment> CreateFakePayments()
        {
            var payments = new List<Payment>()
            {
                new Payment
                {
                    Id = new Guid("cc99afbd-c379-4ba0-910b-3c4849192a5c"),
                    OrderId = new Guid("8cb145fc-42fd-4aad-82b9-f8a8c8e3bdab"),
                    Amount = 265.3,
                    Status = PaymentStatus.InProcess
                },
                new Payment
                {
                    Id = new Guid("cf970046-3124-4e9b-83c6-002b24d8eea4"),
                    OrderId = new Guid("bae97295-a71a-45fa-a3ce-554fdeeb0475"),
                    Amount = 650.45,
                    Status = PaymentStatus.InProcess
                },
                new Payment
                {
                    Id = new Guid("d7018d7a-3ce3-4083-aabe-e610f21a1e0d"),
                    OrderId = new Guid("da18b8db-0fbb-42b9-9197-b0db28f740f9"),
                    Amount = 850.3,
                    Status = PaymentStatus.InProcess
                },
                new Payment
                {
                    Id = new Guid("9f6b9d51-8c70-4294-932a-b3919e2cce7d"),
                    OrderId = new Guid("1c32d74f-d1fa-4870-ae4e-fefcf00926c7"),
                    Amount = 654.74,
                    Status = PaymentStatus.InProcess
                }
            }.AsQueryable();

            return payments;
        }
    }
}
