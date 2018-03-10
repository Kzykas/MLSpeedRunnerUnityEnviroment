using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeColor))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CubeColor cube = (CubeColor)target;

        GUILayout.Label("Oscililates around a base size.");
        cube.baseSize = EditorGUILayout.Slider("Size", cube.baseSize, 1f, 2f);
        cube.transform.localScale = Vector3.one * cube.baseSize;

        GUILayout.BeginHorizontal();
            if (GUILayout.Button("Generate Color"))
            {
                cube.GenerateColor();
            }
            if (GUILayout.Button("Reset"))
            {
                cube.Reset();
            }
        GUILayout.EndHorizontal();
    }
}
