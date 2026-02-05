using Core.Infrastructure.GameStates.Interfaces;
using Core.Progress;
using Factories;


namespace Core.Infrastructure.GameStates
{
    public class LoadMetaState : IEnterableState
    {
        private readonly ISaveLoadService saveLoadService;
        private readonly MetaUIFactory metaUIFactory;


        public LoadMetaState(ISaveLoadService saveLoadService, MetaUIFactory metaUIFactory)
        {
            this.saveLoadService = saveLoadService;
            this.metaUIFactory = metaUIFactory;
        }


        public void Enter()
        {
            saveLoadService.UpdateProgress();
        }
    }
}