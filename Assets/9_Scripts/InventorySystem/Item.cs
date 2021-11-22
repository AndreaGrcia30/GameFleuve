using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Item : MonoBehaviour
{
    [SerializeField]
    List<string> properties = new List<string>();
    InventoryItem invItem;

    public InventoryItem InvItem {get => invItem; set => invItem = value;}
    public List<string> Properties => properties;
}
