using Core.Progress;
using Core.SigBus;
using Core.SigBus.Signals;
using UnityEngine;
using VContainer;


namespace Core.Economy
{
    public class EconomyManager : IEconomyManager, IProgressSaver, IProgressUpdater
    {
        public int Coins { get; private set; }
        public int Gems { get; private set; }
        private readonly SignalBus signalBus;
        private readonly ISaveLoadService saveLoadService;


        public EconomyManager(SignalBus signalBus, ISaveLoadService saveLoadService)
        {
            this.saveLoadService = saveLoadService;
            this.signalBus = signalBus;
        }


        public void Init()
        {
            saveLoadService.RegisterGlobalObject(this);
        }


        public void AddCoins(int amount)
        {
            Coins += amount;
            signalBus.Fire(new CoinsChangedSignal(Coins));
        }


        public void AddGems(int amount)
        {
            Gems += amount;
            signalBus.Fire(new GemsChangedSignal(Gems));
        }


        public bool TrySpendCoins(int amount)
        {
            if (Coins - amount < 0)
            {
                return false;
            }

            Coins -= amount;
            return true;
        }


        public bool TrySpendGems(int amount)
        {
            if (Gems - amount < 0)
            {
                return false;
            }

            Gems -= amount;
            return true;
        }


        public void SaveProgress(PlayerProgress playerProgress)
        {
            playerProgress.currencyData.coins = Coins;
            playerProgress.currencyData.gems = Gems;
        }


        public void UpdateProgress(PlayerProgress playerProgress)
        {
            Coins = playerProgress.currencyData.coins;
            Gems = playerProgress.currencyData.gems;
        }
    }
}
