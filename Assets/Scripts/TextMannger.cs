using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMannger : MonoBehaviour
{
    [SerializeField] Text text;


    Animator anim;

    private void Awake()
    {
        text = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.Play("Play_To_Touch");
    }
}
