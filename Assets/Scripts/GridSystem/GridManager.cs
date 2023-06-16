using System.Collections.Generic;
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
        private List<GridPoint> _points;
#region UNITY_METHODS

        private void Awake()
        {
            _gemController = GetComponent<GridGemController>();
            InitPoints();
        }

#endregion


#region PUBLIC_METHODS
        public void CreateGridPoints()
        {
            _points = new List<GridPoint>();
            var startGridPos = new Vector3(transform.position.x - ((RowAndColumn.x - 1) / 2) * Space,
                transform.position.y,
                transform.position.z + ((RowAndColumn.y - 1) / 2) * Space);
            
            for (var i = 0; i < RowAndColumn.y; i++)
            {
                for (var j = 0; j < RowAndColumn.x; j++)
                {
                    var pointPos = new Vector3(startGridPos.x + (j * Space), startGridPos.y,
                        startGridPos.z - (i * Space));
                    SpawnGripPoint(pointPos);
                }
            }
        }

        public void ClearGridPoints()
        {
            if (PointParent.childCount <= 0)
                return;
            for (var i = PointParent.childCount-1; i >= 0; i--)
            {
                var point = PointParent.GetChild(i);
                DestroyImmediate(point.gameObject);
            }
        }
#endregion


#region PRIVATE_METHODS

        private void InitPoints()
        {
            _points = new List<GridPoint>();
            foreach (Transform child in PointParent.transform)
            {
                if(!child.TryGetComponent(out GridPoint point))
                    continue;
                _points.Add(point);
            }
            for (var i = 0; i < _points.Count; i++)
            {
                var point = _points[i];
                point.InitPoint(i,_gemController);
            }
        }

        private void SpawnGripPoint(Vector3 pointPosition)
        {
            var point = Instantiate(Point, pointPosition, Quaternion.identity, PointParent);
        }

#endregion
    }
}