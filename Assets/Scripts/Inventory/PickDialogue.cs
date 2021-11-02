using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PickDialogue : MonoBehaviour
{
    public string dialogue;
    public string[] sentences;
    private DialogueManager dMan;
    public bool dialogueActive;
    public GameObject dBox;
    public TextMeshProUGUI textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void ShowBox(string dialogue)
     {
            dialogueActive = true;
            dBox.SetActive(true);
            textDisplay.text = dialogue;

    }

     void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
                dMan.ShowBox(dialogue);
            Debug.Log("yes");
        }
    }
}

     
