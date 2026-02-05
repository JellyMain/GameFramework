using Const;
using Core.Assets;
using Core.StaticData.Data;
using Cysharp.Threading.Tasks;


namespace Core.StaticData.Services
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider assetProvider;
        public LevelConfig LevelConfig { get; private set; }
        public AdRewardsConfig AdRewardsConfig { get; private set; }


        public StaticDataService(IAssetProvider assetProvider)
        {
            this.assetProvider = assetProvider;
        }


        public async UniTask LoadStaticData()
        {
            UniTask loadLevelConfigTask = LoadLevelsConfig();
            UniTask loadAdRewardsConfigTask = LoadAdRewardsConfig();

            UniTask[] loadTasks =
            {
                loadLevelConfigTask,
                loadAdRewardsConfigTask
            };

            await UniTask.WhenAll(loadTasks);
        }


        private async UniTask LoadLevelsConfig()
        {
            LevelConfig = await assetProvider.LoadAsset<LevelConfig>(RuntimeConstants.StaticDataAddresses.LEVEL_CONFIG);
        }


        private async UniTask LoadAdRewardsConfig()
        {
            AdRewardsConfig =
                await assetProvider.LoadAsset<AdRewardsConfig>(RuntimeConstants.StaticDataAddresses.AD_REWARDS_CONFIG);
        }
    }
}
