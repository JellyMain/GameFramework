using Core.Infrastructure.GameStates;
using Core.Infrastructure.Services;
using VContainer.Unity;


namespace Core.Infrastructure
{
    public class Bootstrapper : IStartable
    {
        private readonly GameStateMachine gameStateMachine;


        public Bootstrapper(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }


        public void Start()
        {
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}
