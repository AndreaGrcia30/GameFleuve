using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textDisplay;
    [SerializeField]
    string[] sentences;
    private int index;
    private float typingSpeed;
    [SerializeField]
    GameObject continueButton;
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject dBox;
    private bool dialogueActive;

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        animator.SetBool("IsOpen", true);
        StartCoroutine(Type());
    }

    void  Update() {
       if(dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
        {
            if(textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            animator.SetBool("IsOpen", false);
            dBox.SetActive(false);
            dialogueActive = false;
            Time.timeScale = 1;

        }
    }

    public void ShowBox(string dialogue)
     {
        dialogueActive = true;
        dBox.SetActive(true);
        textDisplay.text = dialogue;
    }
}
//TODO: quiero utilizar Time.timeScale = 0; para hacer freeze al jugador 
//mientras haya dialogo pero no se donde ponerlo
