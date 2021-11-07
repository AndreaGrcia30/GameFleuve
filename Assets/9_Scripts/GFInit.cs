using System;
using System.Collections;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultLayers;
using UnityEngine.Promise;

public class GFInit : MonoBehaviour
{
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
        const string definitionKey = "sandwich";
        InventoryItemDefinition definition = GameFoundationSdk.catalog.Find<InventoryItemDefinition>(definitionKey);
        if (definition is null)
        {
        Debug.Log($"Definition {definitionKey} not found");
        return;
        }
        Debug.Log($"Definition {definition.key} '{definition.displayName}' found.");
        InventoryItem item = GameFoundationSdk.inventory.CreateItem(definition);

        Debug.Log($"Item {item.id} of definition '{item.definition.key}' created");

        bool removed = GameFoundationSdk.inventory.Delete(item);

        if (!removed)
        {
        Debug.LogError($"Unable to remove item {item.id}");
        return;
        }

        Debug.Log($"Item {item.id} successfully removed. Its discarded value is {item.hasBeenDiscarded.ToString()}");
    }

   
    void OnInitFailed(Exception error)
    {
        Debug.LogException(error);
    }
}
