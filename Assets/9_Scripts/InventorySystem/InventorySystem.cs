using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.GameFoundation;

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
        //logica para cargar los items en las slots vacias
    }

    void OnEnable()
    {
        foreach (InventoryItem item in GameManager.instance.GetGameFoundation.Items)
        {
            Debug.Log($"Item {item.id} of definition '{item.definition.key}' created");
        }
    }
}
