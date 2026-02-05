using Const;
using Core.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;


namespace Factories
{
    public class MetaUIFactory : BaseFactory
    {
        public MetaUIFactory(IAssetProvider assetProvider, IObjectResolver objectResolver) :
            base(objectResolver, assetProvider) { }


        protected override void WarmUpPrefabs() { }
    }
}
