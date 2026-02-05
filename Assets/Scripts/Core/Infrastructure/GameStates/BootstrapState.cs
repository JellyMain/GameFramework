using Core.Infrastructure.GameStates.Interfaces;
using Core.Infrastructure.Services;


namespace Core.Infrastructure.GameStates
{
    public class BootstrapState : IEnterableState
    {
        private readonly GameStateMachine gameStateMachine;


        public BootstrapState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }


        public void Enter()
        {
            gameStateMachine.Enter<LoadProgressState>();
        }
    }
}
