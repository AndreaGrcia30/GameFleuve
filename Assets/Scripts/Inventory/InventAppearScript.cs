using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventAppearScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas CanvasObject; // Assign in inspector
 
     void Start()
     {
        CanvasObject.enabled = false;
     }
 
     void Update() 
     {
         if (Input.GetKeyUp(KeyCode.Q)) 
         {
            if(CanvasObject.enabled == false)
            {
                CanvasObject.enabled = true;
                Time.timeScale = 0;
            }  else {
                CanvasObject.enabled = false;
                Time.timeScale = 1;
            }
             
         }
     }
 
}
