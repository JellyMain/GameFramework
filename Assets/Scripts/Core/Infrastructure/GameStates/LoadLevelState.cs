using Core.Infrastructure.GameStates.Interfaces;
using Core.Infrastructure.Services;
using Gameplay.Base;


namespace Core.Infrastructure.GameStates
{
    public class LoadLevelState : IEnterableState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly BaseGameplayController gameplayController;


        public LoadLevelState(GameStateMachine gameStateMachine, BaseGameplayController gameplayController)
        {
            this.gameStateMachine = gameStateMachine;
            this.gameplayController = gameplayController;
        }


        public void Enter()
        {
            gameplayController.Init();
            gameStateMachine.Enter<GameLoopState>();
        }
    }
}
