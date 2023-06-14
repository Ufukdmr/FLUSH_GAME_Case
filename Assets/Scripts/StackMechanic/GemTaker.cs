using System;
using System.Collections.Generic;
using System.Linq;
using Gems;
using UnityEngine;
using UnityEngine.Serialization;

namespace StackMechanic
{
    public class GemTaker : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//
        [SerializeField] private StackArea PlayerStackArea;
        [SerializeField] private LayerMask GemLayer;

       [SerializeField] private float CollectRadius;

//------Private Variables-------//
        private bool _canCollect=true;
        private int _frameInterval=1;
        private int _nearestGemCount;
        private Collider[] _nearestGems = new Collider[8];
        private List<GemController> _gems;
 
#region UNITY_METHODS

        private void Update()
        {
            if (!_canCollect)
                return;
            CheckNearestGems();
            if (_nearestGemCount <= 0)
                return;
            if (Time.frameCount % _frameInterval == 0)
            {
                var targetGem = CheckCollectableGems();
                if (!targetGem)
                    return;
                _canCollect = false;
                targetGem.transform.SetParent(PlayerStackArea.transform);
                targetGem.MoveToTargetPosition(PlayerStackArea.GetStackYPosition(), () =>
                {
                    PlayerStackArea.CollectGem();
                    _canCollect = true;
                });
            }

        }

#endregion


#region PUBLIC_METHODS

#endregion


#region PRIVATE_METHODS

        private GemController CheckCollectableGems()
        {
            _gems = new List<GemController>();
            for (var i = 0; i < _nearestGemCount; i++)
            {
                var hitCollider = _nearestGems[i];
                if(!hitCollider.TryGetComponent(out GemController gem))
                    continue;
                if(!gem.IsGemInteractable())
                    continue;
                _gems.Add(gem);
            }

            if (_gems.Count <= 0)
                return null;
            var nearestGem = _gems[0];
            var nearestDistance = Vector3.Distance(transform.position, nearestGem.transform.position);

            for (var i = 0; i < _gems.Count; i++)
            {
                
                var gem = _gems[i];
                var distance = Vector3.Distance(transform.position, gem.transform.position);
                if (distance < nearestDistance)
                {
                    nearestGem = gem;
                    nearestDistance = distance;
                }
            }

            return nearestGem;
        }

        private void CheckNearestGems()
        {
            if (Time.frameCount % _frameInterval == 0)
            {
                _nearestGemCount = Physics.OverlapSphereNonAlloc(transform.position, CollectRadius,
                    _nearestGems, GemLayer);
            }
        }
#endregion
    }
}