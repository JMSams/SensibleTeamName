using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpiderWeb))]
public class SpiderWebEditor : Editor
{
    SpiderWeb t { get { return target as SpiderWeb; } }

    static bool autoUpdate = true;

    public override void OnInspectorGUI()
    {
        bool newAutoUpdate = EditorGUILayout.Toggle("Auto Update", autoUpdate);
        if (newAutoUpdate != autoUpdate && newAutoUpdate)
            t.CreateWeb();
        autoUpdate = newAutoUpdate;

        if (t.lines == null)
            t.CreateWeb();

        if (autoUpdate)
            EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        if (autoUpdate && EditorGUI.EndChangeCheck())
            t.CreateWeb();
    }
}