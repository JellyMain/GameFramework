using System;
using Core.Assets;
using Core.Progress;
using Cysharp.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Core.Scenes
{
    public class SceneLoader
    {
        private readonly LoadingScreen loadingScreen;
        private readonly ISaveLoadService saveLoadService;
        private readonly IAssetProvider assetProvider;


        public SceneLoader(LoadingScreen loadingScreen, ISaveLoadService saveLoadService, IAssetProvider assetProvider)
        {
            this.loadingScreen = loadingScreen;
            this.saveLoadService = saveLoadService;
            this.assetProvider = assetProvider;
        }


        public void Load(string sceneName, Action callback = null)
        {
            LoadScene(sceneName, callback).Forget();
        }


        private async UniTaskVoid LoadScene(string sceneName, Action callback)
        {
            loadingScreen.Show();
            saveLoadService.Cleanup();
            assetProvider.Cleanup();

            AsyncOperation loadNextScene = SceneManager.LoadSceneAsync(sceneName);

            while (!loadNextScene.isDone)
            {
                await UniTask.Yield();
            }

            callback?.Invoke();

            loadingScreen.Hide();
        }
    }
}
