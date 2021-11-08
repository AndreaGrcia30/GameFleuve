using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuPausa : MonoBehaviour
{
     Canvas CanvasObjects;  
     Animator animator;
 
     void Start()
     {
         CanvasObjects.enabled = false;
         CanvasObjects = GetComponent<Canvas> ();
         
     }
 
     void Update() 
     {
         if (Input.GetKeyDown(KeyCode.Escape)) 
         {
            if(CanvasObjects.enabled == false)
            {
                animator.SetBool("IsOpen", true);
                CanvasObjects.enabled = true;
                //Time.timeScale = 0;
            }  else {
                
                Return();
                
            }
             
         }
     }
  
 public void Return()
  {
      animator.SetBool("IsOpen", false);
      CanvasObjects.enabled = false;
      Time.timeScale = 1;

  }

  
  }



