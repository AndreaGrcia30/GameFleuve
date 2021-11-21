using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using GameLib.MemorySystem;

public class Pantalla_Inicio : MonoBehaviour
{
     [SerializeField]
    Button btnLoadGame;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    void Awake() {
        {
             btnLoadGame.onClick.AddListener(LoadGame);
        }
    }

      void LoadGame()
    {
        MemorySystem.LoadGame("gamedata");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleport()
    {
            SceneManager.LoadScene("LVL1");
    }
}
