using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class PlayerState
    {
        protected Player _player;
        protected PlayerStateMachine _playerStateMachine;
        protected Animator _myAnimator;


        public PlayerState(Player player, PlayerStateMachine playerStateMachine, Animator animator)
        {
            this._player = player;
            this._playerStateMachine = playerStateMachine;
            this._myAnimator = animator;
        }

        public virtual void EnterState()
        {

        }
        public virtual void ExitState()
        {

        }
        public virtual void FrameUpdate() 
        {
            
        }
        public virtual void PhysicsUpdate()
        {

        }
        public virtual void AnimationTriggerEvent(Player.AnimationTriggerType triggerType) { }
    }
}
