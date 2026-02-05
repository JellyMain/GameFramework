using Core.Analytics;
using Core.Assets;
using Core.Economy;
using Core.Infrastructure.Services;
using Core.Monetization;
using Core.Progress;
using Core.Rewards;
using Core.Scenes;
using Core.SigBus;
using Core.StaticData.Services;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Core.Infrastructure.Installers.Global
{
    public class InfrastructureInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen loadingScreenPrefab;


        public override void Install(IContainerBuilder builder)
        {
            BindBootstrapper(builder);
            BindPersistentPlayerProgress(builder);
            BindSaveLoadService(builder);
            BindStaticDataService(builder);
            BindContainerService(builder);
            BindAssetProvider(builder);
            BindSceneLoader(builder);
            BindEconomyManager(builder);
            BindSignalBus(builder);
            BindAnalyticsService(builder);
            BindMonetizationService(builder);
            BindRewardService(builder);
            BindAppCoordinator(builder);
            CreateAndBindLoadingScreen(builder);
        }


        private void BindAppCoordinator(IContainerBuilder builder)
        {
            builder.Register<AppCoordinator>(Lifetime.Singleton);
        }


        private void BindRewardService(IContainerBuilder builder)
        {
            builder.Register<RewardService>(Lifetime.Singleton).AsImplementedInterfaces();
        }


        private void BindMonetizationService(IContainerBuilder builder)
        {
            builder.Register<MonetizationMock>(Lifetime.Singleton).AsImplementedInterfaces();
        }


        private void BindAnalyticsService(IContainerBuilder builder)
        {
            builder.Register<AnalyticsMock>(Lifetime.Singleton).AsImplementedInterfaces();
        }


        private void BindSignalBus(IContainerBuilder builder)
        {
            builder.Register<SignalBus>(Lifetime.Singleton);
        }


        private void BindEconomyManager(IContainerBuilder builder)
        {
            builder.Register<EconomyManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }


        private void BindBootstrapper(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Bootstrapper>();
        }


        private void BindPersistentPlayerProgress(IContainerBuilder builder)
        {
            builder.Register<PersistentPlayerProgress>(Lifetime.Singleton);
        }


        private void BindSaveLoadService(IContainerBuilder builder)
        {
            builder.Register<SaveLoadService>(Lifetime.Singleton).AsImplementedInterfaces();
        }


        private void BindStaticDataService(IContainerBuilder builder)
        {
            builder.Register<StaticDataService>(Lifetime.Singleton).AsImplementedInterfaces();
        }


        private void BindContainerService(IContainerBuilder builder)
        {
            builder.Register<ContainerService>(Lifetime.Singleton);
        }


        private void BindAssetProvider(IContainerBuilder builder)
        {
            builder.Register<AssetProvider>(Lifetime.Singleton).AsImplementedInterfaces();
        }


        private void BindSceneLoader(IContainerBuilder builder)
        {
            builder.Register<SceneLoader>(Lifetime.Singleton);
        }


        private void CreateAndBindLoadingScreen(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(loadingScreenPrefab, Lifetime.Singleton);
        }
    }
}
