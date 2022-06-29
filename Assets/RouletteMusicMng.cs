using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteMusicMng : MonoBehaviour
{
    public AudioSource Speaker;
    [SerializeField] private AudioClip[] clip;
      
    void Start()
    {
        
        Speaker = GetComponent<AudioSource>();
        
    }


    public void FirstSong()
    {
        StartCoroutine("playsong");
    }
    public void SecondSong()
    {

        Speaker.clip = clip[2];
        Speaker.loop = false;
        Speaker.Play();
    }
    IEnumerator playsong()
    {
        Speaker.clip = clip[0];
        Speaker.Play();
        yield return new WaitForSeconds(0.2f);
        Speaker.clip = clip[1];
        Speaker.loop = true;
        Speaker.Play(); 
    }
}
