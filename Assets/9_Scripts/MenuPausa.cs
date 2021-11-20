using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using GameLib.MemorySystem;

public class MenuPausa : MonoBehaviour
{
    [SerializeField]
    AnimationClip hideClip;
    [SerializeField]
    AnimationClip showClip;
    [SerializeField]
    GameObject pauseMenu;
    Animator pauseMenuAnim;

    [SerializeField]
    Button btnContinue;
    [SerializeField]
    Button btnSaveGame;
    [SerializeField]
    Button btnNewGame;

    bool animatorIsRunning = false;

    bool CancelButton => Input.GetButton("Cancel");

     void Start() 
     {
        // MemorySystem.NewGame("juegoperron");
        //MemorySystem.LoadGame("gamedata");
        //MemorySystem.SaveGame(new GameData(GameManager.instance.GetHealth.CurrentHealth, 1, GameManager.instance.GetGameFoundation.ItemDefinitionKeys.ToArray()), "gamedata");
    }

    void Awake()
    {
        pauseMenuAnim = pauseMenu.GetComponent<Animator>();
        btnContinue.onClick.AddListener(AnimateMenu);
        btnSaveGame.onClick.AddListener(SaveGame);
        btnNewGame.onClick.AddListener(NewGame);
    }

    void Update()
    {
        if(CancelButton)
        {
            AnimateMenu();
        }
    }

    void SaveGame()
    {
        MemorySystem.SaveGame(GameManager.instance.CurrentGameData, "gamedata");
        AnimateMenu();
    }

    void NewGame()
    {
        string GameName = "LastGame" + System.DateTime.Now.ToString("hh:mm");
        Debug.Log(GameName);
        MemorySystem.NewGame(GameName);
        MemorySystem.NewGame("gamedata");
        AnimateMenu();
    }

    void AnimateMenu()
    {
        if(!animatorIsRunning)
        {
            animatorIsRunning = true;
            if(pauseMenu.activeSelf)
            {
                StartCoroutine(Hide());
            }
            else
            {
                StartCoroutine(Show());
            }
        }
    }

    IEnumerator Show()
    {
        pauseMenu.SetActive(true);
        pauseMenuAnim.SetTrigger("show");
        yield return new WaitForSeconds(showClip.length);
        animatorIsRunning = false;
    }

    IEnumerator Hide()
    {
        pauseMenuAnim.SetTrigger("hide");
        yield return new WaitForSeconds(hideClip.length);
        animatorIsRunning = false;
        pauseMenu.SetActive(false);
    }
    public static FileInfo[] FilePaths => new DirectoryInfo(Application.persistentDataPath + "/").GetFiles("*.data*");
   
}



