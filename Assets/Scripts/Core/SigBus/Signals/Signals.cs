namespace Core.SigBus.Signals
{
    public class ClickSignal { }

    public class CoinsChangedSignal
    {
        public readonly int currentAmount;


        public CoinsChangedSignal(int currentAmount)
        {
            this.currentAmount = currentAmount;
        }
    }

    public class GemsChangedSignal
    {
        public readonly int currentAmount;


        public GemsChangedSignal(int currentAmount)
        {
            this.currentAmount = currentAmount;
        }
    }

    public class RequestAdSignal
    {
        public readonly string adPlacementId;


        public RequestAdSignal(string adPlacementId)
        {
            this.adPlacementId = adPlacementId;
        }
    }
    
    public class GameStartRequestedSignal { }
    
    public class PlayAgainRequestedSignal { }
}
