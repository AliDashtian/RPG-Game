using CartoonHeroes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestEditorInspector))]
public class TestEditor : Editor
{
    const int defaultSpace = 8;



    public override void OnInspectorGUI()
    {
        TestEditorInspector editorInspector = (TestEditorInspector)target;

        base.OnInspectorGUI();

        serializedObject.Update();

        GUILayout.Space(defaultSpace);

        GUIContent content = new GUIContent();
        content.text = "DropDown";

        EditorGUILayout.DropdownButton(content, FocusType.Passive);

        if (GUILayout.Button("Move Forward"))
        {
            editorInspector.player.transform.Translate(Vector3.forward);
        }
    }
}
