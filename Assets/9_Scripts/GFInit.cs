using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultLayers;
using UnityEngine.Promise;

public class GFInit : MonoBehaviour
{
    [SerializeField]
    List<InventoryItem> items = new List<InventoryItem>();
    List<string> itemDefinitionKeys = new List<string>();


    IEnumerator Start()
    {
        MemoryDataLayer dataLayer = new MemoryDataLayer();

        using (Deferred initDeferred = GameFoundationSdk.Initialize(dataLayer))
        {
            yield return initDeferred.Wait();

            if (initDeferred.isFulfilled)
                OnInitSucceeded();
            else
                OnInitFailed(initDeferred.error);
        }
    }


    void OnInitSucceeded()
    {
        Debug.Log("Game Foundation is successfully initialized");
        /*const string itemName = "sandwich";
        InventoryItemDefinition itemDefiniton = GetItem(itemName);*/
    }


    void OnInitFailed(Exception error)
    {
        Debug.LogException(error);
    }

    public InventoryItemDefinition GetItem(string itemName) => GameFoundationSdk.catalog.Find<InventoryItemDefinition>(itemName);
    public InventoryItem CreateItem(InventoryItemDefinition itemDefiniton) => GameFoundationSdk.inventory.CreateItem(itemDefiniton);
    public Property GetStaticProperty(InventoryItemDefinition itemDefiniton, string propertyKey) => itemDefiniton.GetStaticProperty(propertyKey);
    public int ItemCount => GameFoundationSdk.inventory.GetItems();
    public void AddItemToInventory(InventoryItem item) => items.Add(item);
    public void AddItemDefinitionKeyToInventory(string item)
    {
        itemDefinitionKeys.Add(item);
        GameManager.instance.UpdateItemsInCurrentData();
    }
    public List<InventoryItem> Items => items;
    public List<string> ItemDefinitionKeys => itemDefinitionKeys;

    public void DeleteItem(InventoryItem item)
    {
        items.Remove(item);
        itemDefinitionKeys.Remove(item.definition.key);
        GameManager.instance.UpdateItemsInCurrentData();
    }

    public InventoryItem GetItemById(string id) => GameFoundationSdk.inventory.FindItem(id);

    public void Clear()
    {
        GameFoundationSdk.inventory.DeleteAllItems();
        items.Clear();
        itemDefinitionKeys.Clear();
    }
}
