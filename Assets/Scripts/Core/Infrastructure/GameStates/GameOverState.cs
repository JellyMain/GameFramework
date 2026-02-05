using Core.Infrastructure.GameStates.Interfaces;
using Cysharp.Threading.Tasks;
using Factories;
using Gameplay.Base;


namespace Core.Infrastructure.GameStates
{
    public class GameOverState : IPayloadState<bool>
    {
        private readonly GameplayUIFactory gameplayUIFactory;


        public GameOverState(GameplayUIFactory gameplayUIFactory)
        {
            this.gameplayUIFactory = gameplayUIFactory;
        }


        public void Enter(bool isWin)
        {
            gameplayUIFactory.CreateWinScreen().Forget();
        }
    }
}
