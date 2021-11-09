using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
     string dialogue;
     string[] sentences;
     DialogueManager dMan;
    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
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
                dMan.ShowBox(dialogue);
            }
        }
    }
}
