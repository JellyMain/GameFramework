using Core.Infrastructure.GameStates.Interfaces;
using Gameplay.Base;
using UnityEngine;


namespace Core.Infrastructure.GameStates
{
    public class GameLoopState : IEnterableState
    {
        private readonly BaseGameplayController gameplayController;


        public GameLoopState(BaseGameplayController gameplayController)
        {
            this.gameplayController = gameplayController;
        }


        public void Enter()
        {
            gameplayController.StartGame();
        }
    }
}
