using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

namespace Lifeness
{
    public class Player : MonoBehaviour
    {
        [SerializeField] PlayerController _playerController;
        //[SerializeField] int _JumpHeight;
        [SerializeField] public Animator _myAnimator;
        [SerializeField] public PlayerMadness playerMadness;
        Rigidbody _rb;

        #region State Machine Fields
        public PlayerStateMachine stateMachine;
        public PlayerWalkState playerWalkState;
        public PlayerIdleState playerIdleState;
        public PlayerBackwardState playerBackwardState;
        public PlayerAttackState playerAttackState;
        public PlayerRunState playerRunState;
        public PlayerRightSideState playerRightSideState;
        public PlayerLeftSideState playerLeftSideState;
        #endregion

        private void Awake()
        {
            stateMachine = new PlayerStateMachine();
            playerWalkState = new PlayerWalkState(this, stateMachine, _myAnimator);
            playerIdleState = new PlayerIdleState(this, stateMachine, _myAnimator);
            playerBackwardState = new PlayerBackwardState(this, stateMachine, _myAnimator);
            playerAttackState = new PlayerAttackState(this, stateMachine, _myAnimator);
            playerRunState = new PlayerRunState(this, stateMachine, _myAnimator);
            playerRightSideState = new PlayerRightSideState(this, stateMachine, _myAnimator);
            playerLeftSideState = new PlayerLeftSideState(this, stateMachine, _myAnimator);
            stateMachine.Initialize(playerIdleState);
        }

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            //_playerController.onJump += Jump;
            //_playerController.OnHorizontal += Horizontal;
            //_playerController.OnVertical += Vertical;
        }
        
        void Update()
        {
            stateMachine.currentPlayerState.FrameUpdate();
        }
        void FixedUpdate()
        {
            stateMachine.currentPlayerState.PhysicsUpdate();
        }
        //void Jump()
        //{
        //    _rb.AddForce(Vector3.up * _JumpHeight, ForceMode.Impulse);
        //}
        #region Movement
        void Horizontal(float value)
        {
            //int speed = _PlayerSpeed;
            
            //if (_playerController.isHorizontal && _playerController.isRunning) speed = _PlayerRunSpeed;

            //if (_playerController.isHorizontal)
            //{
            //    Vector3 currentVelocity = new Vector3(value * speed, _rb.velocity.y, _rb.velocity.z);
            //    _rb.velocity = currentVelocity;
            //}

        }
        void Vertical(float value)
        {
            //if(_playerController.isVertical && !_playerController.isRunning )
            //{
            //    Vector3 currentVelocity = new Vector3(_rb.velocity.x, _rb.velocity.y, value * _PlayerSpeed);
            //    _rb.velocity = currentVelocity;
            //}

        }

       
        #endregion

        #region Anim
        private void AnimationTriggerEvent(AnimationTriggerType triggerType)
        {
            stateMachine.currentPlayerState.AnimationTriggerEvent(triggerType);
        }

        public enum AnimationTriggerType
        {
            idle,
            walk,
            run,
            attack,
            back,
            leftSide,
            rightSide,
        }

        #endregion

    }
}
