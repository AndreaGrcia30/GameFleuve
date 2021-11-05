using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    GameObject mainContainer;
    [SerializeField]
    Transform itemsSlotsTransform;
    [SerializeField]
    List<ItemSlot> itemSlots = new List<ItemSlot>();

    void Start()
    {
        foreach(Transform t in itemsSlotsTransform)
        {
            itemSlots.Add(t.GetComponent<ItemSlot>());
        }
    }

    public void AddItem(ItemSlot itemSlot)
    {
        ItemSlot emptyItemSlot = itemSlots.FirstOrDefault(itemSlot => string.IsNullOrEmpty(itemSlot.ItemId));
    }
}
