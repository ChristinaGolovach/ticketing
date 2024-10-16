namespace Modules.Orders.Core.Models
{
    public class ViewOrderItemDto
    {
        public Guid Id { get; set; }
        public Guid ActivitySeatId { get; set; }
        public double Amount { get; set; }
    }
}
