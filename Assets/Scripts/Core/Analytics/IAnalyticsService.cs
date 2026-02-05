using System.Collections.Generic;


namespace Core.Analytics
{
    public interface IAnalyticsService
    {
        public void LogEvent(string eventName, Dictionary<string, object> parameters = null);
    }
}
