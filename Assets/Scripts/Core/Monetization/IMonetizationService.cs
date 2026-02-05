using System;


namespace Core.Monetization
{
    public interface IMonetizationService
    {
        public void ShowRewardedVideo(string placement, Action onComplete, Action onFailed = null);
    }
}
