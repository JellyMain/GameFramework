using System;
using Core.Economy;
using Core.SigBus;
using Core.SigBus.Signals;
using TMPro;
using UnityEngine;
using VContainer;


namespace UI
{
    public class BalanceUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text coinsBalanceText;
        [SerializeField] private TMP_Text gemsBalanceText;
        private SignalBus signalBus;
        private IEconomyManager economyManager;


        [Inject]
        private void Construct(SignalBus signalBus, IEconomyManager economyManager)
        {
            this.economyManager = economyManager;
            this.signalBus = signalBus;
        }


        private void Start()
        {
            signalBus.Subscribe<CoinsChangedSignal>(UpdateCoinsBalanceText);
            signalBus.Subscribe<GemsChangedSignal>(UpdateGemsBalanceText);
            UpdateCoinsBalanceText(new CoinsChangedSignal(economyManager.Coins));
            UpdateGemsBalanceText(new GemsChangedSignal(economyManager.Gems));
        }


        private void UpdateCoinsBalanceText(CoinsChangedSignal signal)
        {
            coinsBalanceText.text = $"Coins:{signal.currentAmount}";
        }


        private void UpdateGemsBalanceText(GemsChangedSignal signal)
        {
            gemsBalanceText.text = $"Gems:{signal.currentAmount}";
        }
    }
}
