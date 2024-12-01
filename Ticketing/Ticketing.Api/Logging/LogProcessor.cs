using OpenTelemetry;
using OpenTelemetry.Logs;
using System.Diagnostics;

namespace Ticketing.Api.Logging
{
    public class LogProcessor : BaseProcessor<LogRecord>
    {
        public override void OnEnd(LogRecord data)
        {
            base.OnEnd(data);
            var currentActivity = Activity.Current;
            if (data.LogLevel == LogLevel.Error)
            {
                currentActivity?.AddException(data.Exception);
            }
            else
            {
                currentActivity?.AddEvent(new ActivityEvent(data.Attributes.ToString()));
            }
        }
    }
}
