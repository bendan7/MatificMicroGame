using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, ItemData> _itemsData;
    private UserData _userData;
    private CustomizationType _currentSelectedSection = CustomizationType.Outfits;
    private Dictionary<CustomizationType, List<GameObject>> _customization = new Dictionary<CustomizationType, List<GameObject>>();

    public GameObject CustomizationGrid;
    public GameObject ValidItemPrefab;
    public GameObject LevelLockItemPrefab;
    public GameObject CoinsLockItemPrefab;

    public GameObject OutfitObj;
    public GameObject EyesObj;
    public GameObject MouthObj;

    private void Awake()
    {
        var userData = UserDataGetter.GetUserData();
        UpdateUserState(userData);

        _itemsData = ItemsDataGetter.GetItemsData();
        
        LoadItemsFromFolder(CustomizationType.Outfits, "Customization", "CustomizationIcons",10);
        LoadItemsFromFolder(CustomizationType.Eyes, "EyesCharacter", "EyesIcons",10);
        LoadItemsFromFolder(CustomizationType.Mouths, "MouthCharacter", "MouthIcons",10);

    }

    void Start()
    {
        // defualt selected section 
        OnSectionButtonClick("Outfits");
    }

    private void UpdateUserState( UserData userData)
    {
        _userData = userData;
        GameObject.Find("UserStateText").GetComponent<TextMeshProUGUI>().text = $"Level: {userData.Level}   Coins: {userData.Coins}";
    }

    private void LoadItemsFromFolder(CustomizationType type, string imagesPath, string iconsPath ,int maxItemsToLoad)
    {
        var icons = Resources.LoadAll<Sprite>(iconsPath);
        var images = Resources.LoadAll<Sprite>(imagesPath);


        if(icons.Length != images.Length)
        {
            Debug.LogError("Icons and Imges Folders is not match");
        }


        var listOfItems = new List<GameObject>();

        for (int i=0; i< images.Length && i< maxItemsToLoad; i++)
        {
            Sprite itemImage = images[i];
            string itemId = ExtractId(images[i].name);
            Sprite itemIcon = icons.First(icon => icon.name.Contains(itemId));

            ItemStatus itemStatus = CheckItemStates(itemImage.name);

            GameObject newItem = CreateNewItem(type, itemImage, itemId, itemIcon, itemStatus);

            listOfItems.Add(newItem);
        }


        _customization.Add(type, listOfItems);
    }

    private GameObject CreateNewItem(CustomizationType type, Sprite itemImage, string itemId, Sprite itemIcon, ItemStatus itemStatus)
    {
        GameObject newItem;

        switch (itemStatus)
        {
            case ItemStatus.Available:
                newItem = Instantiate(ValidItemPrefab, CustomizationGrid.transform);
                break;

            case ItemStatus.PendingPurchase:
                newItem = Instantiate(CoinsLockItemPrefab, CustomizationGrid.transform);
                var price = _itemsData[itemImage.name].Price.ToString();
                newItem.transform.GetComponentInChildren<TextMeshProUGUI>().text = price;
                break;

            case ItemStatus.LockByLevel:
                newItem = Instantiate(LevelLockItemPrefab, CustomizationGrid.transform);
                var minLevel = _itemsData[itemImage.name].MinLevel.ToString();
                newItem.transform.GetComponentInChildren<TextMeshProUGUI>().text = minLevel;
                break;

            default:
                newItem = Instantiate(ValidItemPrefab, CustomizationGrid.transform);
                break;
        }

        newItem.transform.localScale = Vector3.one;

        newItem.GetComponent<Button>().onClick.AddListener(() => SetItemOnCharacter(type, itemImage, itemStatus));

        var itemInfo = newItem.AddComponent<ItemInfo>();
        itemInfo.Type = type;
        itemInfo.id = itemId;
        itemInfo.Icon = itemIcon;
        itemInfo.Image = itemImage;


        // Set icon & update the size base on icon sizes
        var iconSprite = newItem.transform.GetChild(0).GetComponent<Image>();
        var rectTransform = newItem.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(itemInfo.Icon.rect.width, itemInfo.Icon.rect.height);
        iconSprite.sprite = itemIcon;


        newItem.SetActive(false);
        return newItem;
    }

    private string ExtractId(string name)
    {
        var arr = name.Split('_');
        foreach(var str in arr)
        {

            if (str.All(char.IsDigit))
            {
                return str;
            }


        }

        Debug.LogError($"File name: {name} is not contain id");
        return "";

    }

    private void SetItemOnCharacter(CustomizationType type, Sprite itemImage, ItemStatus itemStats)
    {
        if(itemStats!= ItemStatus.Available)
        {
            return;
        }

        switch (type)
        {
            case CustomizationType.Outfits:
                OutfitObj.GetComponent<SpriteRenderer>().sprite = itemImage;
                break;
            case CustomizationType.Eyes:
                EyesObj.GetComponent<SpriteRenderer>().sprite = itemImage;
                break;
            case CustomizationType.Mouths:
                MouthObj.GetComponent<SpriteRenderer>().sprite = itemImage;
                break;

        }
    }

    private ItemStatus CheckItemStates(string itemName)
    {
        var itemData =  _itemsData[itemName];

        if(itemData.MinLevel > _userData.Level)
        {
            return ItemStatus.LockByLevel;
        }

        if (itemData.Price > 0)
        {
            return ItemStatus.PendingPurchase;
        }

        return ItemStatus.Available;

    }

    public void OnSectionButtonClick(string selectedSectionStr)
    {
        var newSelectedSection = (CustomizationType)Enum.Parse(typeof (CustomizationType), selectedSectionStr);

        foreach (var item in _customization[_currentSelectedSection])
        {
            item.SetActive(false);
        }

        foreach (var item in _customization[newSelectedSection])
        {
            item.SetActive(true);
        }


        _currentSelectedSection = newSelectedSection;

    }

}
