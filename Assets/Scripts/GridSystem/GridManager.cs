using System;
using Lean.Pool;
using UnityEngine;

namespace GridSystem
{
    public class GridManager : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//
        [SerializeField] private Vector2 RowAndColumn;
        [SerializeField] private float Space;
        [SerializeField] private GridPoint Point;

        [SerializeField] private Transform PointParent;

//------Private Variables-------//
        private GridGemController _gemController;
#region UNITY_METHODS

        private void Awake()
        {
            _gemController = GetComponent<GridGemController>();
            InitGrids();
        }

#endregion


#region PUBLIC_METHODS

#endregion


#region PRIVATE_METHODS

        private void InitGrids()
        {
            var startGridPos = new Vector3(transform.position.x - ((RowAndColumn.x - 1) / 2) * Space,
                transform.position.y,
                transform.position.z + ((RowAndColumn.y - 1) / 2) * Space);

            var index = 0;
            for (var i = 0; i < RowAndColumn.y; i++)
            {
                for (var j = 0; j < RowAndColumn.x; j++)
                {
                    var pointPos = new Vector3(startGridPos.x + (j * Space), startGridPos.y,
                        startGridPos.z - (i * Space));
                    SpawnGripPoint(pointPos,index);
                    index++;
                }
            }
        }

        private void SpawnGripPoint(Vector3 pointPosition,int index)
        {
            var point = LeanPool.Spawn(Point, pointPosition, Quaternion.identity, PointParent);
            point.InitPoint(index,_gemController);
        }

#endregion
    }
}