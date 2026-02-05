using System;


namespace Core.Rewards
{
    public interface IRewardService
    {
        public void TryGrantReward(string placementId);
        public void Init();
    }
}