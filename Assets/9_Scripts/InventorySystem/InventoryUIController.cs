using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    HealthBar healthBar;
    [SerializeField]
    InventorySystem inventorySystem;

    // Update is called once per frame
    void Update()
    {
        if(OpenInventory)
        {
            inventorySystem.gameObject.SetActive(!inventorySystem.gameObject.activeSelf);
        }
    }

    bool OpenInventory => Input.GetButtonDown("Inventory");
    public HealthBar GetHealthBar => healthBar;
    public InventorySystem GetInventorySystem => inventorySystem;
}
