using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    GameObject inventorySystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OpenInventory)
        {
            inventorySystem.SetActive(!inventorySystem.activeSelf);
        }
    }

    bool OpenInventory => Input.GetButtonDown("Inventory");
}
