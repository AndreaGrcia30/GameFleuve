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

    public string ItemId {get => itemId; set => itemId = value;}
    public Image ItemImage => itemImage;
    public string ItemName {get => itemName; set => itemName = value;}
}
