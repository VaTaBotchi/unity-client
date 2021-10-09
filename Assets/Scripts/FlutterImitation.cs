using UnityEngine;

public class FlutterImitation : MonoBehaviour
{
    public string itemName;
    public bool itemEnabled;
    public string emotionName;
    public bool emotionEnabled;
    public string cameraStateName;
    
    private int _currentId;
    
    public void SetItemData()
    {
        _currentId++;
        
        var itemData = new ItemData()
        {
            id = _currentId,
            name = itemName,
            enabled = itemEnabled
        };

        var outData = JsonUtility.ToJson(itemData);
        FlutterController.Instance.SetItem(outData);
    }

    public void SetEmotionData()
    {
        _currentId++;

        var emotionData = new EmotionData()
        {
            id = _currentId,
            name = emotionName,
            enabled = emotionEnabled
        };

        var outData = JsonUtility.ToJson(emotionData);
        FlutterController.Instance.SetEmotion(outData);
    }

    public void SetCameraState()
    {
        _currentId++;

        var cameraData = new CameraData()
        {
            id = _currentId,
            name = cameraStateName
        };

        var outData = JsonUtility.ToJson(cameraData);
        FlutterController.Instance.SetCameraState(outData);
    }
}