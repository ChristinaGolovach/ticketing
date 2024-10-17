namespace Modules.Orders.Core.Models
{
    public class ViewOrderDto
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public double Amount { get; set; }
        public IList<ViewOrderItemDto> OrderItems { get; set; }

        //TODO ASK
        //public string ActivityName { get; set; }
        //public DateTime ActivityDate { get; set; }
        //public string VenueName { get; set; }
        //public string VenueAddress { get; set; }
    }
}
