using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpiderWeb))]
public class SpiderWebEditor : Editor
{
    SpiderWeb t { get { return target as SpiderWeb; } }

    bool autoUpdate = true;

    public override void OnInspectorGUI()
    {
        autoUpdate = EditorGUILayout.Toggle("Auto Update", autoUpdate);

        if (t.lines == null)
            t.CreateWeb();

        if (autoUpdate)
            EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        if (autoUpdate && EditorGUI.EndChangeCheck())
            t.CreateWeb();
    }
}