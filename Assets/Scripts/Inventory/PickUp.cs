using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    private GameObject itemButton;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            for (int i = 0; i < inventory.Slots.Length; i++)
            {
                if (inventory.IsFull[i] == false) {
                    inventory.IsFull[i] = true;
                    Instantiate(itemButton, inventory.Slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

}
