namespace Modules.Events.Core.Models
{
    public class ViewVenueDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildNumber { get; set; }
    }
}
