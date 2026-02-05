using Const;
using Core.Assets;
using Core.Economy;
using Core.Infrastructure.GameStates.Interfaces;
using Core.Infrastructure.Services;
using Core.Progress;
using Core.Rewards;
using Core.Scenes;
using Core.StaticData.Services;


namespace Core.Infrastructure.GameStates
{
    public class LoadProgressState : IEnterableState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly IStaticDataService staticDataService;
        private readonly ISaveLoadService saveLoadService;
        private readonly PersistentPlayerProgress persistentPlayerProgress;
        private readonly SceneLoader sceneLoader;
        private readonly IEconomyManager economyManager;
        private readonly IAssetProvider assetProvider;
        private readonly IRewardService rewardService;
        private readonly AppCoordinator appCoordinator;


        public LoadProgressState(GameStateMachine gameStateMachine, IStaticDataService staticDataService,
            ISaveLoadService saveLoadService, PersistentPlayerProgress persistentPlayerProgress,
            SceneLoader sceneLoader, IEconomyManager economyManager, IAssetProvider assetProvider,
            IRewardService rewardService, AppCoordinator appCoordinator)
        {
            this.gameStateMachine = gameStateMachine;
            this.staticDataService = staticDataService;
            this.saveLoadService = saveLoadService;
            this.persistentPlayerProgress = persistentPlayerProgress;
            this.sceneLoader = sceneLoader;
            this.economyManager = economyManager;
            this.assetProvider = assetProvider;
            this.rewardService = rewardService;
            this.appCoordinator = appCoordinator;
        }


        public async void Enter()
        {
            await staticDataService.LoadStaticData();
            LoadSavesOrCreateNew();
            InitGlobalServices();
            sceneLoader.Load(RuntimeConstants.Scenes.MAIN_MENU_SCENE, () => gameStateMachine.Enter<LoadMetaState>());
        }


        private void InitGlobalServices()
        {
            assetProvider.Init();
            economyManager.Init();
            rewardService.Init();
            appCoordinator.Init();
        }


        private void LoadSavesOrCreateNew()
        {
            persistentPlayerProgress.PlayerProgress = LoadOrCreateNewProgress();
        }



        private PlayerProgress LoadOrCreateNewProgress()
        {
            PlayerProgress playerProgress = saveLoadService.LoadProgress() ?? new PlayerProgress();
            return playerProgress;
        }
    }
}
