using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class MusicMng : MonoBehaviour
{

    int SongNum = 0;
    [SerializeField] AudioSource MusicPlayer;


    void Start()
    {
        MusicPlayer = GetComponent<AudioSource>();

        MusicPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
