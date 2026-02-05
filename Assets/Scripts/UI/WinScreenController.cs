using System;
using System.Collections.Generic;
using Core.Analytics;
using Core.Economy;
using Core.Monetization;
using Core.Rewards;
using Core.SigBus;
using Core.SigBus.Signals;
using UnityEngine;
using UnityEngine.UI;
using VContainer;


namespace UI
{
    public class WinScreenController : MonoBehaviour
    {
        [SerializeField] private Button retryButton;
        [SerializeField] private Button adMockButton;
        private SignalBus signalBus;


        [Inject]
        private void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }


        private void OnEnable()
        {
            adMockButton.onClick.AddListener(RequestAd);
            retryButton.onClick.AddListener(PlayAgain);
        }


        private void OnDisable()
        {
            adMockButton.onClick.RemoveListener(RequestAd);
            retryButton.onClick.RemoveListener(PlayAgain);
        }


        private void RequestAd()
        {
            signalBus.Fire(new RequestAdSignal("additional_gems"));
        }


        private void PlayAgain()
        {
            Destroy(gameObject);
            signalBus.Fire(new PlayAgainRequestedSignal());
        }
    }
}
