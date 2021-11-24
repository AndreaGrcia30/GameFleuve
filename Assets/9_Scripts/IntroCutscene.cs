using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroCutscene : MonoBehaviour
{
    [SerializeField]
    Button btnNext;
   
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        btnNext.onClick.AddListener(EndCutscene);
    }
    void EndCutscene()
        { 
            SceneManager.LoadScene("LVL1", LoadSceneMode.Single);
        }
}
