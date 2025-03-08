using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;


namespace Lifeness
{
    public class CameraManager : MonoBehaviour
    {
        private float _distanceToPlayer;

        Vector2 _input;

        [SerializeField] private Transform _target;

        [SerializeField] MouseSensitivity _mouseSensitivity;
        [SerializeField] CameraAngle _cameraAngle;

        CameraRotation _cameraRotation;

        public void Awake() => _distanceToPlayer = Vector3.Distance(transform.position, _target.position);

        public void Look(InputAction.CallbackContext context)
        {
            _input = context.ReadValue<Vector2>();
        }
        void Update()
        {
            _cameraRotation.Yaw += _input.x * _mouseSensitivity.horizontal * BoolToInt(_mouseSensitivity.invertHorizontal) * Time.deltaTime;
            _cameraRotation.Pitch += _input.y * _mouseSensitivity.vertical * BoolToInt(_mouseSensitivity.invertVertical) * Time.deltaTime;
            _cameraRotation.Pitch = Mathf.Clamp(_cameraRotation.Pitch, _cameraAngle.min, _cameraAngle.max); 
        }

        private void LateUpdate()
        {
            transform.eulerAngles = new Vector3(_cameraRotation.Pitch, _cameraRotation.Yaw, 0.0f);
            transform.position = _target.position - transform.forward * _distanceToPlayer + transform.up;
        }

        private static int BoolToInt(bool b) => b ? 1 : -1;
    }

    [Serializable]
    public struct MouseSensitivity
    {
        public float horizontal;
        public float vertical;
        public bool invertVertical;
        public bool invertHorizontal;
    }

    public struct CameraRotation
    {
        public float Pitch;
        public float Yaw;
    }

    [Serializable]
    public struct CameraAngle
    {
        public float min;
        public float max;
    }
}
