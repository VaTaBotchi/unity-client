using System.Collections.Generic;
using UnityEngine;

public class FlutterImitation : MonoBehaviour
{
    public string itemName;
    public bool itemEnabled;
    public string emotionName;
    public bool emotionEnabled;
    public string cameraStateName;

    private int currentId;
    
    private readonly List<string> itemNames = new List<string>()
    {
        "hat-crown", "hat-cowboy", "hat-magician", "hat-shower", "hat-viking"
    };
    private readonly List<string> skinNames = new List<string>()
    {
        "skin-blue", "skin-red", "skin-yellow"
    };
    private readonly List<string> faceNames = new List<string>()
    {
        "face-sick", "face-dead", "face-money", "face-closed", "face-love"
    };
    
    static System.Random random = new System.Random();

    public void SetItemData()
    {
        currentId++;
        
        var itemData = new ItemData()
        {
            id = currentId,
            name = itemName,
            enabled = itemEnabled
        };

        var outData = JsonUtility.ToJson(itemData);
        FlutterController.Instance.SetItem(outData);
    }

    public void SetEmotionData()
    {
        currentId++;

        var emotionData = new EmotionData()
        {
            id = currentId,
            name = emotionName,
            enabled = emotionEnabled
        };

        var outData = JsonUtility.ToJson(emotionData);
        FlutterController.Instance.SetEmotion(outData);
    }

    public void RandomLook()
    {
        currentId++;
        
        var itemData = new ItemData()
        {
            id = currentId,
            name = itemNames[random.Next(itemNames.Count)],
            enabled = true
        };

        var outItemData = JsonUtility.ToJson(itemData);
        FlutterController.Instance.SetItem(outItemData);
        
        var skinData = new ItemData()
        {
            id = currentId,
            name = skinNames[random.Next(skinNames.Count)],
            enabled = true
        };

        var outSkinData = JsonUtility.ToJson(skinData);
        FlutterController.Instance.SetItem(outSkinData);
        
        var faceData = new ItemData()
        {
            id = currentId,
            name = faceNames[random.Next(faceNames.Count)],
            enabled = true
        };

        var outFaceData = JsonUtility.ToJson(faceData);
        FlutterController.Instance.SetItem(outFaceData);
    }

    public void SetCameraState()
    {
        currentId++;

        var cameraData = new CameraData()
        {
            id = currentId,
            name = cameraStateName
        };

        var outData = JsonUtility.ToJson(cameraData);
        FlutterController.Instance.SetCameraState(outData);
    }
}