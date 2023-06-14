using System;
using DG.Tweening;
using UnityEngine;

namespace Gems
{
    public class GemController : MonoBehaviour
    {
//-------Public Variables-------//
        public GemData Data;

        public Action OnCollected;
//------Serialized Fields-------//
        [SerializeField] private float ScaleUpTime;
        [SerializeField] private Ease ScaleUpEase;
        [SerializeField] private float InteractableScale = .25f;

//------Private Variables-------//
        private bool _isCollected;
        private Tween _scaleTween;
#region UNITY_METHODS

        private void OnDisable()
        {
            transform.localScale = Vector3.zero;
            _isCollected = false;
        }

#endregion


#region PUBLIC_METHODS

        public void InitGem()
        {
            _scaleTween?.Kill();
            _scaleTween=transform.DOScale(Vector3.one, ScaleUpTime).SetEase(ScaleUpEase);
        }

        public bool IsGemInteractable()
        {
            if (_isCollected)
                return false;
            
            return  transform.localScale.x >= InteractableScale;
        }

       

        public void MoveToTargetPosition(float yPos, Action onCompleted = null)
        {
            _scaleTween?.Kill();
            _isCollected = true;
            OnCollected?.Invoke();
            transform.DOLocalJump(new Vector3(0,yPos,0), .2f, 1, .2f)
                .OnComplete(() => onCompleted?.Invoke()).SetEase(Ease.Linear);
            transform.DOLocalRotate(Vector3.zero, .2f).SetEase(Ease.Linear);
        }
#endregion


#region PRIVATE_METHODS

#endregion
    }
}