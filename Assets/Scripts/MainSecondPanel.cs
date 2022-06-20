using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSecondPanel : MonoBehaviour
{

    public bool isOn;

    Animator anim;

    private void Start()
    {
       anim = GetComponent<Animator>();
    }

    public void SecondPanelOnOff()
    {
        if (isOn == false)
        {
            isOn = true;
            anim.Play("On");
        }
        else
        {
            isOn = false;
            anim.Play("Off");
        }
    }
    public void SecondPanelOff()
    {
        isOn = false;
        anim.Play("Off");
    }
}
