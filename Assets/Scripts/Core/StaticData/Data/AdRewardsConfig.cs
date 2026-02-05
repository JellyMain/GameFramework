using System.Collections.Generic;
using Core.Rewards;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Core.StaticData.Data
{
    [CreateAssetMenu(menuName = "StaticData/AdRewardsConfig", fileName = "AdRewardsConfig")]
    public class AdRewardsConfig : SerializedScriptableObject
    {
        public Dictionary<string, (RewardType type, int amount)> rewards;
    }
}
