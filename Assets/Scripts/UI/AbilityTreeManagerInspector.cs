using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbilityTreeManager))] 
public class AbilityTreeManagerInspector : Editor {
    public override void OnInspectorGUI()
    { 
        AbilityTreeManager manager = (AbilityTreeManager)target;
        manager.SetSelfAsSingletonInstance();
        manager.ButtonPrefab = (GameObject)EditorGUILayout.ObjectField("Prefab", manager.ButtonPrefab, typeof(GameObject), true);
        manager.Center = EditorGUILayout.Vector3Field("Center", manager.Center);
        manager.Radius = EditorGUILayout.IntField("Radius", manager.Radius);
        if (GUILayout.Button("Generate grid"))
        {
            manager.GenerateGrid(); 
        }
    }
}
