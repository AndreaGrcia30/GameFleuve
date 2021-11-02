using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class ConversationTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerExit (Collider2D c)
    {
        if (c.gameObject.tag == "River")
        {
            timeline.Stop();
        }
    }
 
    void OnTriggerEnter (Collider2D c)
    {
        if (c.gameObject.tag == "River")
        {
            timeline.Play();
        }
    }

}
