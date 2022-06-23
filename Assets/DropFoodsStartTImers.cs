using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropFoodsStartTImers : MonoBehaviour
{
    //게임 시작하기 전에 3초 카운트를 적어주기 위한 패널과 텍스트 그리고 문자열이 들어갈 String 과 시간을 적어줄 Int
    public GameObject panel;
    public Text TimerText;
    string TimerString;
    int StartTimer;
    //시작이 되었는지 판단할 아이
    public bool IsStart = false;
    //1초 기준
    float sec1 = 1f;
    //게임을 할 시간 
    int GameTimer = 30;
    //게임이 끝났을 때 사용할 패널과 스트링 과 텍스트 
    public GameObject EndPanel;
    public Text EndText;
    public string EndString;
    private void Start()
    {

        sec1 = 1f;
        GameTimer = 10;
        StartTimer = 3;
        StartCoroutine("StartTimerCourtine");
    }

    IEnumerator StartTimerCourtine()
    {
        if(StartTimer>0)
        {
            if(sec1 >0)
            {
                yield return new WaitForSeconds(0.1f); 
                sec1 -= 0.1f;
            }
            else
            {
                sec1 = 1;
                StartTimer -= 1;

            }

            TimerString = StartTimer.ToString(); 
            TimerText.text = TimerString;
            StartCoroutine("StartTimerCourtine");
        }
        else
        {
            sec1 = 1f;
            IsStart = true;
            panel.SetActive(false);
            StartCoroutine("StartGameTimerCourtine");
        }

        yield return 0;
    }
    IEnumerator StartGameTimerCourtine()
    {
        if (GameTimer > 0)
        {
            if (sec1 > 0)
            {
                yield return new WaitForSeconds(0.1f);
                sec1 -= 0.1f;
            }
            else
            {
                sec1 = 1;
                GameTimer -= 1;

            }

            TimerString = StartTimer.ToString();
            TimerText.text = TimerString;
            StartCoroutine("StartGameTimerCourtine");
        }
        else
        {
         
            IsStart = false;

            yield return new WaitForSeconds(0.1f);
            int ResultSum = GameObject.Find("GameMng").GetComponent<DropFoodsPointMng>().PointsNum;
            EndPanel.SetActive(true);
            EndString = "이번에 획득한 점수는 :" + ResultSum.ToString();
            EndText.text = EndString;

        }

        yield return 0;
    }

}
