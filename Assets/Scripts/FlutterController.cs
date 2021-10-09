using System;
using System.Reflection;
using UnityEngine;
using Utility;

public class FlutterController : Singleton<FlutterController>
{
    public void SetItem(string inData)
    {
        if (string.IsNullOrEmpty(inData))
        {
            SendUnexpectedError(MethodBase.GetCurrentMethod().Name, "Input string is null or empty");
            return;
        }

        var itemData = JsonUtility.FromJson<ItemData>(inData);
        ItemsManager.Instance.SetItem(itemData.name, itemData.enabled);
    }

    public void SetEmotion(string inData)
    {
        if (string.IsNullOrEmpty(inData))
        {
            SendUnexpectedError(MethodBase.GetCurrentMethod().Name, "Input string is null or empty");
            return;
        }

        var emotionData = JsonUtility.FromJson<EmotionData>(inData);
        DinoEmotions.Instance.SetDinoEmotion(emotionData.name, emotionData.enabled);
    }

    public void SetCameraState(string inData)
    {
        if (string.IsNullOrEmpty(inData))
        {
            SendUnexpectedError(MethodBase.GetCurrentMethod().Name, "Input string is null or empty");
            return;
        }
        
        var cameraData = JsonUtility.FromJson<EmotionData>(inData);
        CameraManager.Instance.SetCameraState(cameraData.name);
    }
    
    private static void SendUnexpectedError(string methodName, string info)
    {
        var data = new OutData(0, Result.Error, methodName,info);
        SendMessageToFlutter(data);
    }
    
    private static void SendMessageToFlutter(OutData data)
    {
        var message = JsonUtility.ToJson(data);
        NativeAPI.SendMessageToFlutter(message);
    }
}