using GridSystem;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridManager))]
    public class GridManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var gridManager = (GridManager)target;
            
            if(GUILayout.Button("Create Grid"))
            {
                gridManager.CreateGridPoints();
            }

            if (GUILayout.Button("Clear Points"))
            {
                gridManager.ClearGridPoints();
            }
            base.OnInspectorGUI();
        }
    }
}