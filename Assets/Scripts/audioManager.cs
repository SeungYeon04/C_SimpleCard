using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip bgmusic; //오디오클립과 
    public AudioSource audioSource; //오디오소스

    void Start()
    {
        //계속해서 음악 실행 
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    void Update()
    {
        
    }
}
