using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Creditos : MonoBehaviour
{
     [SerializeField]
    Button btnContinue;
   
    void Awake()
    {
        btnContinue.onClick.AddListener(EndingCutscene);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void EndingCutscene()
        { 
            SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
        }

    
}
