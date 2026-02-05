using Core.Infrastructure.GameStates;
using Core.Infrastructure.Services;
using VContainer;


namespace Core.Infrastructure.Installers.Global
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            BindGameStateMachine(builder);
            BindLoadStates(builder);
        }


        private void BindGameStateMachine(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }


        private void BindLoadStates(IContainerBuilder builder)
        {
            builder.Register<BootstrapState>(Lifetime.Singleton);
            builder.Register<LoadProgressState>(Lifetime.Singleton);
        }
    }
}
