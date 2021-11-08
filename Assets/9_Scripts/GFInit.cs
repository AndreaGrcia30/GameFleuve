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
        const string itemName = "sandwich";
        InventoryItemDefinition itemDefiniton = GetItem(itemName);

        /*Debug.Log($"Name: {itemDefiniton.displayName}, Key: {itemDefiniton.key}");

        InventoryItem itemSandwich = CreateItem(itemDefiniton);

        Debug.Log($"Item {itemSandwich.id} of definition '{itemSandwich.definition.key}' created");

        const string propertyKey = "health";

        Property helthProperty = itemDefiniton.GetStaticProperty(propertyKey);

        Debug.Log($"{itemSandwich.definition.displayName} health: {helthProperty.AsString()}");*/

        //Debug.Log(GameFoundationSdk.inventory.GetItems());
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
    public List<InventoryItem> Items => items;
}
