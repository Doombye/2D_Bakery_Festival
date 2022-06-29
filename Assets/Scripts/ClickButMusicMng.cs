using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButMusicMng : MonoBehaviour
{ 
    [SerializeField] AudioSource MusicPlayer;


    void Start()
    {
        MusicPlayer = GetComponent<AudioSource>();

    }
    public void PressBut()
    {
        MusicPlayer.Play();
    }
}
