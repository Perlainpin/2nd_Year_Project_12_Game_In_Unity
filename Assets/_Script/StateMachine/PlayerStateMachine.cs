using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class PlayerStateMachine
    {
        public PlayerState currentPlayerState;

        public void Initialize(PlayerState startingState)
        {
            currentPlayerState = startingState;
            currentPlayerState.EnterState();
        }

        public void ChangeState(PlayerState newState)
        {
            currentPlayerState.ExitState();
            currentPlayerState = newState;
            currentPlayerState.EnterState();
        }
    }
}
