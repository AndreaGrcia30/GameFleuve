using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.GameFoundation;

public class InventorySystem : MonoBehaviour
{
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

    public void AddItem(InventoryItem item, int index)
    {
        /*ItemSlot emptyItemSlot = itemSlots.FirstOrDefault(itemSlot => string.IsNullOrEmpty(itemSlot.ItemId));
        if(emptyItemSlot)
        {
            emptyItemSlot.ItemId = item.id;
            emptyItemSlot.ItemName = item.definition.key;
            Sprite sprite = Resources.Load<Sprite>(GameManager.instance.GetGameFoundation.GetStaticProperty(item.definition, "sprite"));
            emptyItemSlot.ItemImage.sprite = sprite;
        }*/
        //logica para cargar los items en las slots vacias
        ItemSlot emptyItemSlot = itemSlots[index];
        emptyItemSlot.ItemId = item.id;
        emptyItemSlot.ItemName = item.definition.key;
        Sprite sprite = Resources.Load<Sprite>(GameManager.instance.GetGameFoundation.GetStaticProperty(item.definition, "sprite"));
        emptyItemSlot.ItemSprite = sprite;
        emptyItemSlot.ActiveImage(true);
        emptyItemSlot.ItemImage.sprite = sprite;
    }

    void OnEnable()
    {
        ClearInventoryUI();
        foreach(Transform t in itemsSlotsTransform)
        {
            itemSlots.Add(t.GetComponent<ItemSlot>());
        }

        for(int i = 0; i < GameManager.instance.GetGameFoundation.Items.Count; i ++)
        {
            InventoryItem item = GameManager.instance.GetGameFoundation.Items[i];
            //Debug.Log($"Item {item.id} of definition '{item.definition.key}' created");
            AddItem(item, i);
        }
    }

    void ClearInventoryUI()
    {
        foreach(Transform t in itemsSlotsTransform)
        {
            ItemSlot itemSlot = t.GetComponent<ItemSlot>();
            itemSlot.ItemId = null;
            itemSlot.ItemName = null;
            itemSlot.ItemSprite = null;
            itemSlot.ItemImage.sprite = null;
            itemSlot.ActiveImage(false);
        }
    }
}
