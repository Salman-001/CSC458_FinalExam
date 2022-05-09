using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("escape") || Input.GetKeyDown("p")){

            //pausing
            if(isPaused == false){
                Time.timeScale = 0f;
                GameObject.Find("Ghost").GetComponent<AudioSource>().Stop();
                isPaused = true;
            }else{//resuming
                Time.timeScale = 1f;
                GameObject.Find("Ghost").GetComponent<AudioSource>().Play();
                isPaused = false;
            }
        }
        
    }
}
