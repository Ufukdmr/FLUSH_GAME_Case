using System.Collections.Generic;
using System.Linq;
using Gems;
using Lean.Pool;
using UnityEngine;

namespace GridSystem
{
    public class GridGemController : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//
        [SerializeField] private GemData[] GemData;
//------Private Variables-------//


#region UNITY_METHODS

#endregion


#region PUBLIC_METHODS
        
        public GemController GetGemForIndex(int index)
        {
            return (from data in GemData where data.Index == index select data.GemPrefab).FirstOrDefault();
        }

        public GemData GetRandomGem() => GemData[Random.Range(0, GemData.Length - 1)];

#endregion


#region PRIVATE_METHODS
        
#endregion
    }
}