using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    Image itemImage;
    [SerializeField]
    string itemName;
    [SerializeField]
    string itemId;
    [SerializeField]
    Sprite sprite;

    public string ItemId {get => itemId; set => itemId = value;}
    public Image ItemImage => itemImage;
    public Sprite ItemSprite {get => sprite; set => sprite = value;}
    public string ItemName {get => itemName; set => itemName = value;}
}
