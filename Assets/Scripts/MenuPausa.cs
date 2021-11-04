using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuPausa : MonoBehaviour
{
    [SerializeField]
    AnimationClip hideClip;
    [SerializeField]
    AnimationClip showClip;
    [SerializeField]
    GameObject pauseMenu;
    Animator pauseMenuAnim;

    bool animatorIsRunning = false;

    bool CancelButton => Input.GetButton("Cancel");

    void Awake()
    {
        pauseMenuAnim = pauseMenu.GetComponent<Animator>();
    }

    void Update()
    {
        if(CancelButton && !animatorIsRunning)
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
}



