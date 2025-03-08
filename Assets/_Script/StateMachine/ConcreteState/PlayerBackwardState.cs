using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class PlayerBackwardState : PlayerState
    {
        public PlayerBackwardState(Player player, PlayerStateMachine playerStateMachine, Animator animator) : base(player, playerStateMachine, animator)
        {

        }

        public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType)
        {
            base.AnimationTriggerEvent(triggerType);
        }

        public override void EnterState()
        {
            base.EnterState();
            _myAnimator.SetBool("isBackward", true);
        }

        public override void ExitState()
        {
            base.ExitState();
            _myAnimator.SetBool("isBackward", false);
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
