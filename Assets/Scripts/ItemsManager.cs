using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DinoItem
{
    public string itemName;
    public GameObject itemObject;
    public Material itemMaterial;
    public ItemType itemType;
}

public class ItemsManager : MonoBehaviour
{
    [Header("Skins")]
    [SerializeField] private SkinnedMeshRenderer dinoSkin;
    [SerializeField] private DinoItem[] skins;
    [SerializeField] private string defaultSkin;
    
    [Header("Emotions")] 
    [SerializeField] private SkinnedMeshRenderer dinoFace;
    [SerializeField] private DinoItem[] faces;
    [SerializeField] private string defaultFace;
    
    [Header("Items")]
    [SerializeField] private DinoItem[] hats;
    [SerializeField] private DinoItem moustache;

    private readonly List<DinoItem> _allItems = new List<DinoItem>();
    
    private void Start()
    {
        // Fill items
        _allItems.AddRange(skins);
        _allItems.AddRange(faces);
        _allItems.AddRange(hats);
        _allItems.Add(moustache);

        // Disable items
        foreach (var t in hats)
        {
            t.itemObject.SetActive(false);
        }
        moustache.itemObject.SetActive(false);
        
        // Set default skin
        dinoSkin.material = FindItem(defaultSkin).itemMaterial;
        dinoFace.material = FindItem(defaultFace).itemMaterial;
        
        // Load items from player prefs
        var savedHat = ItemSettings.GetItemSetting(ItemType.Hat);
        if (!string.IsNullOrEmpty(savedHat))
        {
            FindItem(savedHat).itemObject.SetActive(true);
        }

        var savedSkin = ItemSettings.GetItemSetting(ItemType.Skin);
        if (!string.IsNullOrEmpty(savedSkin))
        {
            dinoSkin.material = FindItem(savedSkin).itemMaterial;
        }

        var savedFace = ItemSettings.GetItemSetting(ItemType.Face);
        if (!string.IsNullOrEmpty(savedFace))
        {
            dinoFace.material = FindItem(savedFace).itemMaterial;
        }

        var savedMoustache = ItemSettings.GetItemSetting(ItemType.Moustache);
        moustache.itemObject.SetActive(!string.IsNullOrEmpty(savedMoustache));
    }

    public void SetItem(string name, bool enabled)
    {
        var item = FindItem(name);
        switch (item.itemType)
        {
            case ItemType.Skin:
                SetSkin(item, enabled);
                break;
            case ItemType.Face:
                SetFace(item, enabled);
                break;
            case ItemType.Hat:
                SetHat(item, enabled);
                break;
            case ItemType.Moustache:
                SetMoustache(enabled);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void SetSkin(DinoItem skin, bool enabled)
    {
        
    }
    
    private void SetFace(DinoItem face, bool enabled)
    {
        
    }

    private void SetHat(DinoItem hat, bool enabled)
    {
        
    }

    private void SetMoustache(bool enabled)
    {
        
    }

    private DinoItem FindItem(string itemName)
    {
        foreach (var item in _allItems.Where(item => item.itemName == itemName))
        {
            return item;
        }

        return new DinoItem();
    }
}
