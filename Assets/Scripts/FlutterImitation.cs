using UnityEngine;

public class FlutterImitation : MonoBehaviour
{
    public string itemName;
    public bool itemEnabled;
    
    private int _currentId;
    
    public void SetItemData()
    {
        _currentId++;
        
        var itemData = new ItemData()
        {
            id = _currentId,
            itemName = itemName,
            enabled = itemEnabled
        };

        var outData = JsonUtility.ToJson(itemData);
        FlutterController.Instance.SetItem(outData);
    }
}