using Core.StaticData.Data;
using Cysharp.Threading.Tasks;


namespace Core.StaticData.Services
{
    public interface IStaticDataService
    {
        public LevelConfig LevelConfig { get; }
        public AdRewardsConfig AdRewardsConfig { get; }
        public UniTask LoadStaticData();
    }
}
