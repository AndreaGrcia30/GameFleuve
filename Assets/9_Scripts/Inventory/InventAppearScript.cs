using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventAppearScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject inventoryMenu; // Assign in inspector

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
        if(!inventoryMenu.activeSelf)
        {
            inventoryMenu.SetActive(true);
            Time.timeScale = 0;
            return;
        }  else {
            inventoryMenu.SetActive(false);
            Time.timeScale = 1;
            return;
        }
        }
    }
}
