using System;
using Core.Progress.Data;


namespace Core.Progress
{
    [Serializable]
    public class PlayerProgress
    {
        public CurrencyData currencyData;


        public PlayerProgress()
        {
            currencyData = new CurrencyData();
        }
    }
}
