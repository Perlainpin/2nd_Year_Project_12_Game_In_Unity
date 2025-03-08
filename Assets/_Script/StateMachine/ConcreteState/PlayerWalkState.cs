using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class PlayerWalkState : PlayerState
    {
        
        public PlayerWalkState(Player player, PlayerStateMachine playerStateMachine, Animator animator) : base(player, playerStateMachine, animator)
        {     
        }

        public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType)
        {
            base.AnimationTriggerEvent(triggerType);
        }

        public override void EnterState()
        {
            base.EnterState();
            _myAnimator.SetBool("isWalking", true);

        }

        public override void ExitState()
        {
            base.ExitState();
            _myAnimator.SetBool("isWalking", false);
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
