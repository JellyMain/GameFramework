using Const;
using Core.Infrastructure.GameStates;
using Core.Infrastructure.Services;
using Core.Scenes;
using Core.SigBus;
using Core.SigBus.Signals;


namespace Core.Infrastructure
{
    public class AppCoordinator
    {
        private readonly SceneLoader sceneLoader;
        private readonly SignalBus signalBus;
        private readonly GameStateMachine gameStateMachine;


        public AppCoordinator(SceneLoader sceneLoader, SignalBus signalBus, GameStateMachine gameStateMachine)
        {
            this.sceneLoader = sceneLoader;
            this.signalBus = signalBus;
            this.gameStateMachine = gameStateMachine;
        }


        public void Init()
        {
            signalBus.Subscribe<GameStartRequestedSignal>(EnterLoadLevelState);
            signalBus.Subscribe<PlayAgainRequestedSignal>(EnterGameLoopState);
        }


        private void EnterLoadLevelState(GameStartRequestedSignal signal)
        {
            sceneLoader.Load(RuntimeConstants.Scenes.GAME_SCENE, () => gameStateMachine.Enter<LoadLevelState>());
        }


        private void EnterGameLoopState(PlayAgainRequestedSignal signal)
        {
            gameStateMachine.Enter<GameLoopState>();
            
            
            
        }
    }
}
