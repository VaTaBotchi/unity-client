using UnityEngine;

public enum ItemType
{
    Skin,
    Face,
    Hat,
    Moustache
}

public class ItemSettings
{
    public static void SetItemSetting(ItemType itemType, string value)
    {
        PlayerPrefs.SetString(itemType.ToString(), value);
    }

    public static string GetItemSetting(ItemType itemType)
    {
        return PlayerPrefs.GetString(itemType.ToString(), "");
    }
}