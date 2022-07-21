using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropFoodsStartTImers : MonoBehaviour
{

    [SerializeField] GameObject timerText;
    //게임 시작하기 전에 3초 카운트를 적어주기 위한 패널과 텍스트 그리고 문자열이 들어갈 String 과 시간을 적어줄 Int
    public GameObject panel;
    public GameObject[] Buttons = new GameObject[3];
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

    public Text Timer;
    public Text Point;
    private void Start()
    {

        sec1 = 1f;
       
    }

    public void StartBut()
    {
        GameTimer = 15;
        StartTimer = 3;
        StartCoroutine("StartTimerCourtine");
        for(int i = 0; i<Buttons.Length; i++)
        {
            Buttons[i].SetActive(false);
        }
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
            timerText.SetActive(false);
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

            Timer.text = GameTimer.ToString();
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

            if (ResultSum <= 800)
            {
                DataController.Instance.Ruby += 30;
                EndString = "이거나 먹게.... 30개의 루비를 획득했습니다";
                //제일 낮은 보상
            }
            else if (ResultSum > 800 && ResultSum <= 950)
            {
                DataController.Instance.Ruby += 50;
                EndString = "쓸모가 없진않네";

            }
            else if (ResultSum > 950 && ResultSum <= 1100)
            {
                DataController.Instance.Ruby += 150;
                EndString = "조금만 더 노력해 보게";
            }
            else if (ResultSum > 1100 && ResultSum <= 1200)
            {
                DataController.Instance.Ruby += 200;
                EndString = "하면 되지않나 하하하";
            }
            else if (ResultSum > 1200 && ResultSum <= 1400)
            {
                DataController.Instance.Ruby += 250;
                EndString = "놀랍구만.!!";
            }
            else if (ResultSum > 1400)
            {
                DataController.Instance.Ruby += 300;
                EndString = "뭐하는 사람인가 자네는?";

            }
           
            EndText.text = EndString;

        }

        yield return 0;
    }

}
