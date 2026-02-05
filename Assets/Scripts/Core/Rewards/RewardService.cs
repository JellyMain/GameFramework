using System;
using System.Collections.Generic;
using Core.Analytics;
using Core.Economy;
using Core.Monetization;
using Core.SigBus;
using Core.SigBus.Signals;
using Core.StaticData.Data;
using Core.StaticData.Services;
using UnityEngine;


namespace Core.Rewards
{
    public class RewardService : IRewardService
    {
        private readonly IMonetizationService monetization;
        private readonly IEconomyManager economy;
        private readonly IAnalyticsService analytics;
        private readonly IStaticDataService staticDataService;
        private readonly SignalBus signalBus;
        private AdRewardsConfig adRewardsConfig;


        public RewardService(IMonetizationService monetization, IEconomyManager economy, IAnalyticsService analytics,
            SignalBus signalBus, IStaticDataService staticDataService)
        {
            this.staticDataService = staticDataService;
            this.monetization = monetization;
            this.economy = economy;
            this.analytics = analytics;
            this.signalBus = signalBus;
        }


        public void Init()
        {
            adRewardsConfig = staticDataService.AdRewardsConfig;
            signalBus.Subscribe<RequestAdSignal>(OnAdRequested);
        }


        private void OnAdRequested(RequestAdSignal signal)
        {
            TryGrantReward(signal.adPlacementId);
        }


        public void TryGrantReward(string placementId)
        {
            if (!adRewardsConfig.rewards.ContainsKey(placementId))
            {
                Debug.LogError($"[RewardService] No config for placement: {placementId}");
                return;
            }

            monetization.ShowRewardedVideo(placementId, () => { ApplyReward(placementId); });
        }


        private void ApplyReward(string placementId)
        {
            (RewardType type, int amount) config = adRewardsConfig.rewards[placementId];

            if (config.type == RewardType.Soft)
            {
                economy.AddCoins(config.amount);
            }
            else
            {
                economy.AddGems(config.amount);
            }

            analytics.LogEvent("ad_reward_claimed", new Dictionary<string, object>
            {
                { "placement", placementId },
                { "reward_type", config.type.ToString() },
                { "amount", config.amount }
            });
        }
    }
}
