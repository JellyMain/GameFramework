using Core.Economy;
using Core.Infrastructure.GameStates;
using Core.Infrastructure.Services;
using Core.SigBus;
using Core.SigBus.Signals;
using Core.StaticData.Services;
using Cysharp.Threading.Tasks;
using Factories;
using Gameplay.Base;
using VContainer;


namespace Gameplay.Example
{
    public class ClickerGameplayController : BaseGameplayController
    {
        private GameplayUIFactory gameplayUIFactory;
        private SignalBus signalBus;
        private IEconomyManager economyManager;
        private IStaticDataService staticDataService;
        private ClickCounter clickCounter;
        private int clickTargetCount;
        private GameStateMachine gameStateMachine;


        [Inject]
        private void Construct(GameplayUIFactory gameplayUIFactory, SignalBus signalBus, IEconomyManager economyManager,
            IStaticDataService staticDataService, ClickCounter clickCounter, GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
            this.clickCounter = clickCounter;
            this.staticDataService = staticDataService;
            this.economyManager = economyManager;
            this.signalBus = signalBus;
            this.gameplayUIFactory = gameplayUIFactory;
        }


        public override async void Init()
        {
            //визиваємо один раз при заході на gameplay scene
            clickTargetCount = staticDataService.LevelConfig.clickTargetCount;
            await CreateLevel();
        }


        public override void StartGame()
        {
            clickCounter.Reset();
            signalBus.Subscribe<ClickSignal>(OnClick);
        }


        public override void EndGame(bool isWin)
        {
            Cleanup();
            gameStateMachine.Enter<GameOverState, bool>(isWin);
        }


        public override void Cleanup()
        {
            signalBus.Unsubscribe<ClickSignal>(OnClick);
        }


        private void OnClick(ClickSignal signal)
        {
            clickCounter.AddClick();
            economyManager.AddCoins(1);

            if (clickCounter.ClicksCount >= clickTargetCount)
            {
                EndGame(true);
            }
        }


        private async UniTask CreateLevel()
        {
            await gameplayUIFactory.CreateGameCanvas();
        }
    }
}
