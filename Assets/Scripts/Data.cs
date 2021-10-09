using System;
using UnityEngine.Serialization;

[Serializable]
public class OutData
{
    public int id;
    public string methodName;
    public string result;
    public string message;

    public OutData(int setId, Result setResult, string setMethodName = null, string setMessage = null)
    {
        id = setId;
        methodName = setMethodName;
        result = setResult.ToString();
        message = setMessage;
    }
}
    
public enum Result
{
    Success,
    Error
}

[Serializable]
public class InData
{
    public int id;
}

[Serializable]
public class ItemData : InData
{
    public string name;
    public bool enabled;
}

[Serializable]
public class EmotionData : InData
{
    public string name;
    public bool enabled;
}