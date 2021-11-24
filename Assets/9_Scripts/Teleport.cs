using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Teleport : MonoBehaviour
{
    [SerializeField]
    Button btnNext;
    // Start is called before the first frame update
    void Awake()
    {
         btnNext.onClick.AddListener(EndCutscene);
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

     void EndCutscene()
        { 
            SceneManager.LoadScene("LVL3", LoadSceneMode.Single);
        }

    public void AbandonarTp()
    {
        SceneManager.LoadScene("Pantalla_Inicio");
    }
}    

