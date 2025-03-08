using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lifeness
{
    public class PlayerController : MonoBehaviour
    {
        InputManager _PlayerController;

        [SerializeField] Player _player;


        //[SerializeField] public Animator _myAnimator;

        #region Controller
        private Vector2 _input;
        private CharacterController _characterController;
        private Vector3 _direction;
        [SerializeField] private float _speed;
        BoxCollider _boxCollider;
        #endregion

        #region Camera
        [SerializeField] private float _rotationSpeed = 500.0f;
        private Camera _mainCamera;
        #endregion

        #region Gravity
        private float _gravity = -9.81f;
        [SerializeField] private float _gravityMultiplier = 3.0f;
        private float _velocity;
        #endregion

        public AudioSource _audioSourceWalk;
        public AudioSource _audioSourceRun;

        [SerializeField] private Movement movement;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _boxCollider = GetComponent<BoxCollider>();
            _mainCamera = Camera.main;
        }
        public void move(InputAction.CallbackContext context)
        {
            _input = context.ReadValue<Vector2>();
            _direction = new Vector3(_input.x, 0.0f, _input.y);

        }
        private void CheckSideState()
        {
            if (_input.x == -1.0f)
            {
                _player.stateMachine.ChangeState(_player.playerLeftSideState);
                _audioSourceWalk.enabled = true;
                _audioSourceRun.enabled = false;
            }
            else if (_input.x == 1.0f)
            {
                _player.stateMachine.ChangeState(_player.playerRightSideState);
                _audioSourceWalk.enabled = true;
                _audioSourceRun.enabled = false;
            }
        }

        private void CheckVerticalState()
        {
            if (_input.y == -1.0f)
            {
                _player.stateMachine.ChangeState(_player.playerBackwardState);
                _audioSourceWalk.enabled = true;
                _audioSourceRun.enabled = false;
            }
            else if (_input.y == 1.0f && !movement.isSprinting)
            {
                _player.stateMachine.ChangeState(_player.playerWalkState);
                _audioSourceWalk.enabled = true;
                _audioSourceRun.enabled = false;
            }
        }

        private void CheckIdleState()
        {
            if (_input.x == 0.0f && _input.y == 0.0f)
            {
                _player.stateMachine.ChangeState(_player.playerIdleState);
                _audioSourceWalk.enabled = false;
                _audioSourceRun.enabled = false;
            }
        }

        private void CheckSprintState()
        {
            if(_input.y == 1.0f && movement.isSprinting)
            {
                _player.stateMachine.ChangeState(_player.playerRunState);
                _audioSourceWalk.enabled = false;
                _audioSourceRun.enabled = true;
            }
        }
        private void Update()
        {
            ApplyRotation();
            ApplyGravity();
            ApplyMovement();
            //canShoot();


        }
        private void ApplyGravity()
        {
            if (_characterController.isGrounded && _velocity < 0.0f)
            {
                _velocity = -1.0f;
            }
            else
            {
                _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
            }
            _direction.y = _velocity;
        }
        

        

        private void ApplyRotation()
        {
            if (_input.sqrMagnitude == 0) return;
                
            _direction = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);

            if ((_input.y == 0 &&_input.x != 0) || (_input.y !=1 && _input.x == 0)) return;

            var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        }
        private void ApplyMovement()
        {
            var targetSpeed = movement.isSprinting ? movement.speed * movement.acceleration : movement.speed;
            movement.currentSpeed = Mathf.MoveTowards(movement.currentSpeed, targetSpeed, movement.acceleration * Time.deltaTime);
            _characterController.Move(_direction * movement.currentSpeed * Time.deltaTime);

            CheckSideState();
            CheckVerticalState();
            CheckIdleState();
            CheckSprintState();
        }
        public void Sprint(InputAction.CallbackContext context)
        {
            movement.isSprinting = context.started || context.performed;
        }

        

        [Serializable]
        public struct Movement
        {
            public float speed;
            public float multiplier;
            public float acceleration;

            [HideInInspector] public bool isSprinting;
            [HideInInspector] public float currentSpeed;
        }
    }
}
