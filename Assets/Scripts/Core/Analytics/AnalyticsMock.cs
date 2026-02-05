using System.Collections.Generic;
using UnityEngine;


namespace Core.Analytics
{
    public class AnalyticsMock : IAnalyticsService
    {
        public void LogEvent(string eventName, Dictionary<string, object> parameters = null)
        {
            string log = $"<b>[Analytics]</b> Event: <color=yellow>{eventName}</color>";

            if (parameters != null && parameters.Count > 0)
            {
                foreach (var param in parameters)
                {
                    log += $"\n - {param.Key}: <i>{param.Value}</i>";
                }
            }

            Debug.Log(log);
        }
    }
}
