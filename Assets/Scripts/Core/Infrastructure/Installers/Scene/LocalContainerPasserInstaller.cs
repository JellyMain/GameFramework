using Core.Infrastructure.Services;
using VContainer;
using VContainer.Unity;


namespace Core.Infrastructure.Installers.Scene
{
    public class LocalContainerPasserInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            BindLocalContainerPasser(builder);
        }

        
        private void BindLocalContainerPasser(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LocalContainerPasser>();
        }
    }
}
