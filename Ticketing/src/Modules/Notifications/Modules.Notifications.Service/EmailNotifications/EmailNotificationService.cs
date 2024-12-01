using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Modules.Notifications.Service.Models;
using Polly;
using Polly.Retry;
using SendGrid;
using SendGrid.Helpers.Mail;
using Ticketing.Shared.Infrastructure.Bus.Models;

namespace Modules.Notifications.Service.EmailNotifications
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly ILogger<NotificationsBackgroundService> _logger;
        private readonly ISendGridClient _sendGridClient;
        private readonly AsyncRetryPolicy _retryPolicy;

        public EmailNotificationService(
            ISendGridClient sendGridClient,
            ILogger<NotificationsBackgroundService> logger,
            IOptions<NotificationsConfigurations> notificationsOptions)
        {
            _logger = logger;
            _sendGridClient = sendGridClient;

            _retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(
                    notificationsOptions.Value.RetryCount,
                    attempt => TimeSpan.FromSeconds(notificationsOptions.Value.RetryDelayInSeconds),
                    (exception, timeSpan, context) =>
                    {
                        _logger.LogWarning($"Retrying due to: {exception.Message}");
                    });
        }

        public async Task SendNotificationAsync(NotificationDto notification, CancellationToken cancellationToken)
        {
            foreach (var recipient in notification.Parameters)
            {
                // TODO get rid off hardcode
                var fromEmail = new EmailAddress("christina.golovach@gmail.com", "Ticketing App");
                var toEmail = new EmailAddress(recipient.RecipientEmail, recipient.RecipientName);
                var subject = notification.OperationName;

                var plainTextContent = $"Dear, { recipient.RecipientName }, " + $"{notification.Content.Message}";

                var htmlContent = $"<strong>{plainTextContent}.</strong>";

                var msg = MailHelper.CreateSingleEmail(fromEmail, toEmail, subject, plainTextContent, htmlContent);

                var response = await _retryPolicy.ExecuteAndCaptureAsync(async () =>
                        await _sendGridClient.SendEmailAsync(msg, cancellationToken));

                if (!response.Result.IsSuccessStatusCode)
                {
                    var responseBody = await response.Result.Body.ReadAsStringAsync(cancellationToken);
                    throw new Exception($"Failed to send email via SendGrid: {response.Result.StatusCode} - {responseBody}");
                }

                _logger.LogInformation($"Email sent to {recipient}");
            }
        }
    }
}
