using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class MusicMng : MonoBehaviour
{
    public AudioSource Speaker;
    [SerializeField] private AudioClip[] clip;
    FestivalManager fest;
    bool OnTheFestivalSong = false;

    void Start() 
    {
        fest = GameObject.Find("DataController").GetComponent<FestivalManager>();
        Speaker = GetComponent<AudioSource>();
        DefaultSong();
    } 
 
    
    public void FestivalSong()
    {
        Speaker.clip = clip[1];
        Speaker.Play();
    }
    public void DefaultSong()
    {
        Speaker.clip = clip[0];
        Speaker.Play();
    } 

}
