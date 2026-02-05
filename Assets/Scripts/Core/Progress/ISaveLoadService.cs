namespace Core.Progress
{
    public interface ISaveLoadService
    {
        public void RegisterGlobalObject<T>(T service);
        public void RegisterSceneObject<T>(T service);
        public void SaveProgress();
        public void UpdateProgress();
        public PlayerProgress LoadProgress();
        public void Cleanup();
    }
}
