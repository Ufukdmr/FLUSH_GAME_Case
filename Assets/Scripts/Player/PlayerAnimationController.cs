using System;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//
        [SerializeField] private PlayerJoystickMovement JoystickMovement;
//------Private Variables-------//
        private Animator _anim;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private Tween _speedTween;
        
#region UNITY_METHODS

        private void Awake()
        {
            _anim=GetComponent<Animator>();
            JoystickMovement.OnNormalizedSpeedChange += HandleMovementAnimation;
        }

        private void OnDisable()
        {
            JoystickMovement.OnNormalizedSpeedChange -= HandleMovementAnimation;
        }

#endregion


#region PUBLIC_METHODS

#endregion


#region PRIVATE_METHODS

        private void HandleMovementAnimation(float normalizedSpeed)
        {
            _anim.SetFloat(Speed,normalizedSpeed);


        }
#endregion

    }
}