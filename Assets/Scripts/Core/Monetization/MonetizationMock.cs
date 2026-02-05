using System;
using UnityEngine;


namespace Core.Monetization
{
    public class MonetizationMock : IMonetizationService
    {
        public void ShowRewardedVideo(string placement, Action onComplete, Action onFailed = null)
        {
            Debug.Log($"[Monetization] Showing Rewarded Ad for placement: <color=green>{placement}</color>");

            //Тут припускаємо що ми успішно подивились рекламу
            bool isSuccess = true;

            if (isSuccess)
            {
                Debug.Log("[Monetization] Ad watched successfully.");
                onComplete?.Invoke();
            }
            else
            {
                Debug.LogWarning("[Monetization] Ad failed or was skipped.");
                onFailed?.Invoke();
            }
        }
    }
}
