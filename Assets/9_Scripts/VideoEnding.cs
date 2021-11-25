using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEnding : MonoBehaviour
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
        SceneManager.LoadScene("Pantalla_Inicio", LoadSceneMode.Single);
    }
    
}
