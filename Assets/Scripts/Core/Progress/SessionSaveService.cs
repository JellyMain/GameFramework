using UnityEngine;
using VContainer;


namespace Core.Progress
{
    public class SessionSaveService : MonoBehaviour
    {
        private ISaveLoadService saveLoadService;


        [Inject]
        private void Construct(ISaveLoadService saveLoadService)
        {
            this.saveLoadService = saveLoadService;
        }

        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }


        private void OnApplicationQuit()
        {
            saveLoadService.SaveProgress();
        }


        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                saveLoadService.SaveProgress();
            }
        }
    }
}
