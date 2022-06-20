using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    public GameObject[] Panels = new GameObject[6];
    private int Key = 0;
    private bool IsActive = false;

    
    //2번을 눌렀을때 그전에 누른 키와 지금 켜져있는지를 확인하기 위한 함수
    bool SecondPanelHasActives = false;
    MainSecondPanel secondPanelControll;

    public void FirstButPress()
    {
        GameObject.Find("SecondPanel").GetComponent<MainSecondPanel>().SecondPanelOff();
        Key =1; 
        CheckActive(Key);
    }
    public void SecondButPress()
    {
        GameObject.Find("SecondPanel").GetComponent<MainSecondPanel>().SecondPanelOff();
        //이키는 나머지는 모두 끄게 만들것
        Key = 2;  
        CheckActive(Key);
    }
    public void ThirdPress()
    {
        GameObject.Find("SecondPanel").GetComponent<MainSecondPanel>().SecondPanelOff();
        Key = 3;  
        CheckActive(Key);
    }
    public void FourthPress()
    {
        GameObject.Find("SecondPanel").GetComponent<MainSecondPanel>().SecondPanelOff();
        Key =4;  
        CheckActive(Key);
    }

    public void CheckActive(int _Key)
    {
        if (_Key == 2)
        {
            
            PanelActivities(_Key);
           
        }
        else
        {
            if (Panels[_Key - 1].activeSelf == true)
            {

                Panels[_Key - 1].SetActive(false);

            }
            else
            {
                PanelActivities(_Key);
            }
        }

       
        
    }


    public void PanelActivities(int __Key)
    {
        if (__Key == 2)
        {
           
            for (int i = 0; i < 5; i++)
            { 
                if (i == 1) {
                     
                }
                else
                {
                    Panels[i].SetActive(false);
                }            
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 1)
                {

                }
                else
                {
                    if (i == __Key - 1)
                    {
                        Panels[i].SetActive(true);
                        Debug.Log(i + "번째 패널 켜기 완료!");
                    }
                    
                }


            }
        }
        
    }

}
