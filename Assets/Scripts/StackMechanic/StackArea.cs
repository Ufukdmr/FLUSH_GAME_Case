using System;
using Gems;
using UnityEngine;

namespace StackMechanic
{
    public abstract class StackArea : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//
        [SerializeField] private float SpaceY;
//------Private Variables-------//
        protected bool _canCollect;
        protected int _collectCount;


#region UNITY_METHODS

#endregion


#region PUBLIC_METHODS

        public float GetStackYPosition() => SpaceY * _collectCount;
            

        public void CollectGem()
        {
            _collectCount++;
        }
#endregion


#region PRIVATE_METHODS

#endregion
    }
}