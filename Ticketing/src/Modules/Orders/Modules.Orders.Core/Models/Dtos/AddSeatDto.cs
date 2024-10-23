namespace Modules.Orders.Core.Models.Dtos
{
    public class AddSeatDto
    {
        public Guid ActivitySeatId { get; set; }
        public Guid ActivityId { get; set; }
        public double Amount { get; set; }
    }

    // TODO: fluentvalidation add.
}
