using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.GameFoundation;

public class ItemSlot : MonoBehaviour
{
    InventoryItem inventoryItem;
    Button btnUseItem;
    [SerializeField]
    Button btnDropItem;
    [SerializeField]
    Image itemImage;
    [SerializeField]
    string itemName;
    [SerializeField]
    string itemId;
    [SerializeField]
    Sprite sprite;

    void Awake()
    {
        btnUseItem = GetComponent<Button>();
    }

    void Start()
    {
        btnUseItem.onClick.AddListener(UseItem);
        btnDropItem.onClick.AddListener(DropItem);
    }

    void UseItem()
    {
        InventoryItemDefinition definition = GameManager.instance.GetGameFoundation.GetItem(itemName);
        ItemAction(itemName, definition);
        DropItem();

        /*foreach(var element in definition.GetStaticProperties())
        {
            Debug.Log($"{element.Key} - {element.Value}");
        }*/
    }

    void DropItem()
    {
        Debug.Log("item drop");

        ItemId = null;
        ItemName = null;
        ItemSprite = null;
        ItemImage.sprite = null;
        ActiveImage(false);
        GameManager.instance.GetGameFoundation.DeleteItem(inventoryItem);
        inventoryItem = null;
    }

    void ItemAction(string key, InventoryItemDefinition definition)
    {
        switch(key)
        {
            case "sandwich":
                Property property = GameManager.instance.GetGameFoundation.GetStaticProperty(definition, "health");
                Debug.Log($"jugador se cura: {property} puntos de salud");
                break;
            case "knife":
                //Property property = GameManager.instance.GetGameFoundation.GetStaticProperty(definition, "health");
                break;
            default:
                break;
        }
    }

    public void SetInventoryItem(InventoryItem item) => inventoryItem = item;
    public string ItemId {get => itemId; set => itemId = value;}
    public Image ItemImage => itemImage;
    public Sprite ItemSprite {get => sprite; set => sprite = value;}
    public string ItemName {get => itemName; set => itemName = value;}
    public void ActiveImage(bool show) => itemImage.gameObject.SetActive(show);
}
