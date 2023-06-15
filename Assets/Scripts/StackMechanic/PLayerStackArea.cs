using System;
using System.Collections.Generic;
using Gems;
using UnityEngine;

namespace StackMechanic
{
    public class PLayerStackArea : MonoBehaviour
    {
//-------Public Variables-------//
        public bool IsEmpty => _collectedGems.Count <= 0;
//------Serialized Fields-------//
        [SerializeField] private float SpaceY;
//------Private Variables-------//
       private bool _canCollect;
       private int _collectCount;
       private List<GemController> _collectedGems=new List<GemController>();



#region UNITY_METHODS

#endregion


#region PUBLIC_METHODS

        public float GetStackYPosition() => SpaceY * _collectCount;
            

        public void CollectGem(GemController gem)
        {
            _collectCount++;
            _collectedGems.Add(gem);
        }

        public GemController GetLatestGemFromArea()
        {
            return _collectedGems[_collectCount-1];
        }

        public void RemoveGemFromList(GemController gem)
        {
            _collectedGems.Remove(gem);
            _collectCount--;
        }
#endregion


#region PRIVATE_METHODS

#endregion
    }
}