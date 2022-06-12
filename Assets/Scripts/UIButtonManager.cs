using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    public GameObject[] Panels = new GameObject[6];
    private int Key = 0;
    private bool IsActive = false;
    public void FirstButPress()
    {
        Key = 0;
        CheckActive(Key);
    }
    public void SecondButPress()
    {
        Key =1;
        CheckActive(Key);
    }
    public void ThirdButPress()
    {
        Key =2;
        CheckActive(Key);
    }
    public void FourthButPress()
    {
        Key = 3;
        CheckActive(Key);
    }
    public void FifthButPress()
    {
        Key = 4;
        CheckActive(Key);
    }
    public void SixthButPress()
    {
        Key = 5;
        CheckActive(Key);
    }

    public void CheckActive(int key)
    {
        if( Panels[key].activeSelf == true)
        {
            Panels[key].SetActive(false);
        }
        else
        {
            PanelActivities(Key);
        }
    }


    public void PanelActivities(int Key)
    {
        for (int i = 0; i < 6; i++)
        {
            if(i == Key)
            {
                Panels[i].SetActive(true);
                Debug.Log(i + "번째 패널 켜기 완료!"); 
            }
            else
            {
                Panels[i].SetActive(false); 
            }
            
        }
    }

}
