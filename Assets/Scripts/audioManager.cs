using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip bgmusic; //�����Ŭ���� 
    public AudioSource audioSource; //������ҽ�

    void Start()
    {
        //����ؼ� ���� ���� 
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    void Update()
    {
        
    }
}
