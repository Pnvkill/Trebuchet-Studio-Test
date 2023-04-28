using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClockSpawnAudio : MonoBehaviour
{

    public AudioSource SpawnAudioSource;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SpawnAudioSource.Play();
        }
    }
}
