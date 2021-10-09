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
        
        myTarget.emotionName = EditorGUILayout.TextField("Emotion name:", myTarget.emotionName);
        myTarget.emotionEnabled = EditorGUILayout.Toggle("Emotion enabled: ", myTarget.emotionEnabled);
        if (GUILayout.Button("Set emotion data"))
        {
            myTarget.SetEmotionData();
        }
        
        GUILayout.Space(25f);
        
        myTarget.cameraStateName = EditorGUILayout.TextField("Camera state:", myTarget.cameraStateName);
        if (GUILayout.Button("Set camera data"))
        {
            myTarget.SetCameraState();
        }
    }
}