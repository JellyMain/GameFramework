using UnityEngine;


namespace Gameplay.Base
{
    public abstract class BaseGameplayController : MonoBehaviour
    {
        public abstract void Init();

        public abstract void StartGame();

        public abstract void EndGame(bool isWin);

        public abstract void Cleanup();
    }
}
