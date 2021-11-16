using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    public void AbandonarTp()
    {
        SceneManager.LoadScene("Pantalla_Inicio");
    }
}    

