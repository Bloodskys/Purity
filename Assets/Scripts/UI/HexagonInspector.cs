using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Hexagon))]
[CanEditMultipleObjects]
public class HexagonInspector : Editor {
    public override void OnInspectorGUI()
    {
        Hexagon h = (Hexagon)target;
        EditorGUILayout.LabelField("Hex Position");
        EditorGUILayout.BeginHorizontal();
        Vector3 hexPos = new Vector3();
        GUILayout.Label("Q");
        hexPos.x = EditorGUILayout.FloatField(h.Q);
        GUILayout.Label("R");
        hexPos.y = EditorGUILayout.FloatField(h.R);
        GUILayout.Label("S");
        hexPos.z = EditorGUILayout.FloatField(h.S);
        EditorGUILayout.EndHorizontal();
        h.Position = hexPos;
        h.Size = EditorGUILayout.FloatField("Size", h.Size);
    }
}
