using VContainer.Unity;


namespace Core.Infrastructure.Services
{
    public class LocalContainerPasser: IInitializable
    {
        private readonly LifetimeScope lifetimeScope;
        private readonly ContainerService containerService;


        public LocalContainerPasser(LifetimeScope lifetimeScope, ContainerService containerService)
        {
            this.lifetimeScope = lifetimeScope;
            this.containerService = containerService;
            
        }


        public void Initialize()
        {
            containerService.SetLocalContainer(lifetimeScope);
        }
    }
}
