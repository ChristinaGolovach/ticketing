using Modules.Events.Data.Entities;

namespace Modules.Events.Core.Models
{
    public class ViewActivitySeatDto
    {
        public Guid Id { get; set; }
        public Guid SectionId { get; set; }
        public Guid RowId { get; set; }
        public int? Number { get; set; }
        public int StateId { get; set; }
        public SeatState State { get; set; }
        public int PriceTypeId { get; set; }
        public PriceType PriceType { get; set; }
        public double Amount { get; set; }
        public byte[] Version { get; set; }
    }
}
