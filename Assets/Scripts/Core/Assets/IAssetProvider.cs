using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;


namespace Core.Assets
{
    public interface IAssetProvider
    {
        public void Init();


        public UniTask<IList<T>> LoadAssets<T>(string assetsFolderAddress, Action<T> everyAssetCallback)
            where T : class;


        public UniTask<T> LoadAsset<T>(string assetAddress) where T : class;

        public void Cleanup();
    }
}
