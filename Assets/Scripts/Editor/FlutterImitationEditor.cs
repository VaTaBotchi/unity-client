using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FlutterImitation))]
internal class FlutterImitationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var myTarget = (FlutterImitation)target;

        myTarget.itemName = EditorGUILayout.TextField("Item name:", myTarget.itemName);
        myTarget.itemEnabled = EditorGUILayout.Toggle("Item enabled: ", myTarget.itemEnabled);
        if (GUILayout.Button("Set item data"))
        {
            myTarget.SetItemData();
        }

        GUILayout.Space(25f);
    }
}