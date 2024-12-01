namespace Ticketing.Shared.Infrastructure.Bus.Models
{
    public class NotificationDto
    {
        public Guid Id { get; set; }

        public NotificationType Type { get; set; }

        public string OperationName { get; set; }

        public NotificationContentDto Content { get; set; }

        public List<NotificationParametersDto> Parameters { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
