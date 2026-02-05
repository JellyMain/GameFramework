using System;
using Core.SigBus;
using Core.SigBus.Signals;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using VContainer;


namespace UI
{
    public class ClickerButtonController : MonoBehaviour
    {
        [SerializeField] private Button button;
        private SignalBus signalBus;


        [Inject]
        private void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }


        private void Start()
        {
            button.onClick.AddListener(OnButtonClick);
        }


        private void OnButtonClick()
        {
            signalBus.Fire(new ClickSignal());
        }
    }
}
