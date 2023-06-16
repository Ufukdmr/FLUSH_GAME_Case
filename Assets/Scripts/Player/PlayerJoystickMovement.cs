using System;
using UnityEngine;

namespace Player
{
    public class PlayerJoystickMovement : MonoBehaviour
    {
//-------Public Variables-------//
        public Action<float> OnNormalizedSpeedChange;
//------Serialized Fields-------//
        [SerializeField] private float MaxSpeed;
        [SerializeField] private float RotationSpeed;

//------Private Variables-------//
        private VariableJoystick _joystick;
        private Rigidbody _rigid;
        private float _joystickDistance => new Vector2(_joystick.Horizontal, _joystick.Vertical).magnitude;
        private float _currentSpeed;
        private bool _isActive;

#region UNITY_METHODS

        private void Awake()
        {
            _joystick = FindObjectOfType<VariableJoystick>();
            _rigid = GetComponent<Rigidbody>();
            _isActive = true;
        }

        private void Update()
        {
            if (!_isActive)
                return;
            
            _currentSpeed = _joystickDistance >= .1f ? MaxSpeed*_joystickDistance : 0f;

            OnNormalizedSpeedChange?.Invoke(_joystickDistance);
           
        }

        private void FixedUpdate()
        {
            if (!_isActive)
                return;
            
            HandleMovement();
            HandleRotation();
        }

#endregion


#region PUBLIC_METHODS

#endregion


#region PRIVATE_METHODS

        private void HandleMovement()
        {
            var moveVector = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized * _currentSpeed;
            var targetVelocity = new Vector3(moveVector.x, _rigid.velocity.y, moveVector.z);

            _rigid.velocity = targetVelocity;
        }

        private void HandleRotation()
        {
            var joystickRotation = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);

            if (joystickRotation == Vector3.zero)
                return;
            
            var lookTarget = Quaternion.LookRotation(joystickRotation);
            var rot = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * RotationSpeed);
            transform.rotation = rot;
        }
        
#endregion
    }
}