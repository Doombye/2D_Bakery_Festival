using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteManager : MonoBehaviour
{
    // Start is called before the first frame update
    public RouletteScript GoldRouletteScript;
    public RouletteScript RubyRouletteScript;

    // Update is called once per frame
    void Update()
    {
        if(GoldRouletteScript.IsSpin || GoldRouletteScript.PressBut)
        {
            RubyRouletteScript.CanPressBut = false; 
        }
        else
        {
            RubyRouletteScript.CanPressBut = true;
        }
        if (RubyRouletteScript.IsSpin || RubyRouletteScript.PressBut)
        {
            GoldRouletteScript.CanPressBut = false;
        }
        else
        {
            GoldRouletteScript.CanPressBut = true;
        }
    }
}
