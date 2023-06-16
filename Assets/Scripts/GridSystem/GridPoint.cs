using System;
using DG.Tweening;
using Gems;
using Lean.Pool;
using UnityEngine;

namespace GridSystem
{
    public class GridPoint : MonoBehaviour
    {
//-------Public Variables-------//
        public int GridGemIndex=-1;
        public GemController CurrentGem;
        public bool IsEmpty => !CurrentGem;

        public Action<GridPoint> OnTakeGemToPoint;
//------Serialized Fields-------//

//------Private Variables-------//
        private int _gridPointIndex;
        private GridGemController _gemController;

#region UNITY_METHODS

        private void Awake()
        {
            
        }

#endregion


#region PUBLIC_METHODS

        public void InitPoint(int pointIndex, GridGemController gemController)
        {
            _gridPointIndex = pointIndex;
            _gemController = gemController;
            SpawnGem();
        }

        public void SetGridIndex(int index) => _gridPointIndex = index;


        public void ClearGridPoint()
        {
            CurrentGem.OnCollected -= ClearGridPoint;
            GridGemIndex = -1;
            CurrentGem = null;
            SpawnGem();
        }

#endregion


#region PRIVATE_METHODS

        private void SpawnGem()
        {
            if (GridGemIndex == -1)
            {
                SpawnRandomGem(_gemController.GetRandomGem());
                return;
            }

            var loadedGem = _gemController.GetGemForIndex(_gridPointIndex);
            AddGemToGridPoint(loadedGem);
        }

        private void AddGemToGridPoint(GemController gem)
        {
            CurrentGem = gem;
            GridGemIndex = CurrentGem.Data.Index;
            CurrentGem.InitGem();
            CurrentGem.OnCollected += ClearGridPoint;
        }

        private void SpawnRandomGem(GemData gemData)
        {
            var spawnPoint = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                var gem = LeanPool.Spawn(gemData.GemPrefab, spawnPoint, Quaternion.identity, transform);
                AddGemToGridPoint(gem);
                gem.InitGem();
        }
#endregion
    }
}