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

    Vida health;

    bool animatorIsRunning = false;

    bool CancelButton => Input.GetButton("Cancel");

     void Start() 
     {
         MemorySystem.NewGame("juegoperron");
         MemorySystem.LoadGame("gamedata");
         MemorySystem.SaveGame(new GameData(health.CurrentHealth, 1, GameManager.instance.GetGameFoundation.ItemDefinitionKeys.ToArray()), "gamedata");
    }

    void Awake()
    {
        pauseMenuAnim = pauseMenu.GetComponent<Animator>();
        btnContinue.onClick.AddListener(AnimateMenu);
    }

    void Update()
    {
        if(CancelButton)
        {
            AnimateMenu();
        }
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



