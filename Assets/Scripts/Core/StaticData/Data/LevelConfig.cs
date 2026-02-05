using UnityEngine;


namespace Core.StaticData.Data
{
    [CreateAssetMenu(menuName = "StaticData/LevelConfig", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public int clickTargetCount;
    }
}