namespace Ticketing.Shared.Messaging.ResponseModels
{
    public class SeatStatesResponse
    {
        public Guid SeatId { get; set; }
        public SeatState State { get; set; }
        public byte[] Version { get; set; }
    }
}
