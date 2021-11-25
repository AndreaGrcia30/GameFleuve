using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class Teleport : MonoBehaviour
{
    [SerializeField]
    Button btnNext;
     VideoPlayer player;
    
    
    void Awake()
    {
         btnNext.onClick.AddListener(EndCutscene);
    }

    
    void Update()
    {
        
    }

     void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.name == "River")
        {
           if(Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene("LVL2");
            }
        } 
    }

     void EndCutscene()
        { 
            SceneManager.LoadScene("LVL3", LoadSceneMode.Single);
        }

    public void AbandonarTp()
    {
        SceneManager.LoadScene("Pantalla_Inicio");
    }



    
}
  

