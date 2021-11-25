using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video_secuestroFinal : MonoBehaviour
{
    VideoPlayer player;
    double time;
    double currentTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += End;
        
    }

   

    void End(UnityEngine.Video.VideoPlayer vp){
         player.loopPointReached -= End;
        SceneManager.LoadScene("LVL3", LoadSceneMode.Single);
    }
    
}
