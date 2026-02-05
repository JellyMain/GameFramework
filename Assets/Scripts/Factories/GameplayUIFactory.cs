using Const;
using Core.Assets;
using Cysharp.Threading.Tasks;
using VContainer;


namespace Factories
{
    public class GameplayUIFactory : BaseFactory
    {
        public GameplayUIFactory(IObjectResolver objectResolver, IAssetProvider assetProvider) : base(objectResolver,
            assetProvider) { }


        protected override void WarmUpPrefabs()
        {
            WarmUpPrefab(RuntimeConstants.PrefabAddresses.GAME_CANVAS);
        }



        public async UniTask CreateGameCanvas()
        {
            await InstantiatePrefab(RuntimeConstants.PrefabAddresses.GAME_CANVAS);
        }


        public async UniTask CreateWinScreen()
        {
            await InstantiatePrefab(RuntimeConstants.PrefabAddresses.WIN_SCREEN_CANVAS);
        }
    }
}
