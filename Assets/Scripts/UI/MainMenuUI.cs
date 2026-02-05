using Const;
using Core.Infrastructure.GameStates;
using Core.Infrastructure.Services;
using Core.Scenes;
using Core.SigBus;
using Core.SigBus.Signals;
using UnityEngine;
using UnityEngine.UI;
using VContainer;


namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        private SignalBus signalBus;


        [Inject]
        private void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }


        public void StartGame()
        {
            signalBus.Fire(new GameStartRequestedSignal());
        }
    }
}
