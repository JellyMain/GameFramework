using Core.Infrastructure.GameStates;
using Factories;
using Gameplay;
using Gameplay.Base;
using Gameplay.Example;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Core.Infrastructure.Installers.Scene
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private BaseGameplayController gameplayControllerPrefab;


        public override void Install(IContainerBuilder builder)
        {
            BindGameplayUIFactory(builder);
            BindGameStates(builder);
            BindClickCounter(builder);
            CreateAndBindGameplayController(builder);
        }


        private void BindClickCounter(IContainerBuilder builder)
        {
            builder.Register<ClickCounter>(Lifetime.Singleton);
        }


        private void CreateAndBindGameplayController(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab<BaseGameplayController>(gameplayControllerPrefab, Lifetime.Singleton);
        }



        private void BindGameplayUIFactory(IContainerBuilder builder)
        {
            builder.Register<GameplayUIFactory>(Lifetime.Singleton);
        }


        private void BindGameStates(IContainerBuilder builder)
        {
            builder.Register<LoadLevelState>(Lifetime.Singleton);
            builder.Register<GameLoopState>(Lifetime.Singleton);
            builder.Register<GameOverState>(Lifetime.Singleton);
        }
    }
}
