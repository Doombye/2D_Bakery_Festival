using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RouletteScript : MonoBehaviour
{
    public string RouletteType;
    public bool IsSpin = false;
    //방금 눌렀는가
    public bool PressBut = false;
    //버튼을 누를수 있는 상태인가 
    public bool CanPressBut = true;

    //시작하기전에 의사여부 물어볼 패넣
    public GameObject StartPanel;
    public Text StartPanelText;

    private bool HaveResult = false;
    public float SpinSpeed = 0f;
    public Text ResultText;
    public GameObject ResultPanel;

    RouletteMusicMng RouletteSong;

    public long rouletteGoldCost;
    public long rouletteRubyCost;


    private void Start()
    {
        RouletteSong = GameObject.Find("BGMMng").GetComponent<RouletteMusicMng>();
  

    }
    void Update()
    {
        if (CanPressBut)
        {
            if (PressBut)
            {
                if (!RouletteSong.Speaker.isPlaying)
                    RouletteSong.FirstSong();
                this.SpinSpeed = 15;
            }
            else
            {
                if (SpinSpeed > 0.01)
                {
                    CanPressBut = false;
                    this.SpinSpeed *= 0.99f;
                    IsSpin = true;
                }
                else
                {
                    CanPressBut = true;
                    this.SpinSpeed = 0;
                    IsSpin = false;
                    if (HaveResult)
                    {
                        //Debug.Log(transform.eulerAngles);
                        ResultPanel.SetActive(true);

                        RouletteSong.SecondSong();
                        if (RouletteType == "Gold")
                        {
                            if (this.transform.eulerAngles.z > 0 && this.transform.eulerAngles.z <= 45)
                                ResultText.text = "1만골드 획득!";
                            else if (this.transform.eulerAngles.z > 45 && this.transform.eulerAngles.z <= 90)
                                ResultText.text = "2만골드 획득!";
                            else if (this.transform.eulerAngles.z > 90 && this.transform.eulerAngles.z <= 135)
                                ResultText.text = "3만골드 획득!";
                            else if (this.transform.eulerAngles.z > 135 && this.transform.eulerAngles.z <= 180)
                                ResultText.text = "4만골드 획득!";
                            else if (this.transform.eulerAngles.z > 180 && this.transform.eulerAngles.z <= 225)
                                ResultText.text = "5만골드 획득!";
                            else if (this.transform.eulerAngles.z > 225 && this.transform.eulerAngles.z <= 270)
                                ResultText.text = "6만골드 획득!";
                            else if (this.transform.eulerAngles.z > 270 && this.transform.eulerAngles.z <= 315)
                                ResultText.text = "7만골드 획득!";
                            else if (this.transform.eulerAngles.z > 315 && this.transform.eulerAngles.z <= 360)
                                ResultText.text = "8만골드 획득!";
                        }
                        else
                        {
                            if (this.transform.eulerAngles.z > 0 && this.transform.eulerAngles.z <= 45)
                                ResultText.text = "1만루비 획득!";
                            else if (this.transform.eulerAngles.z > 45 && this.transform.eulerAngles.z <= 90)
                                ResultText.text = "2만루비 획득!";
                            else if (this.transform.eulerAngles.z > 90 && this.transform.eulerAngles.z <= 135)
                                ResultText.text = "3만루비 획득!";
                            else if (this.transform.eulerAngles.z > 135 && this.transform.eulerAngles.z <= 180)
                                ResultText.text = "4만루비 획득!";
                            else if (this.transform.eulerAngles.z > 180 && this.transform.eulerAngles.z <= 225)
                                ResultText.text = "5만루비 획득!";
                            else if (this.transform.eulerAngles.z > 225 && this.transform.eulerAngles.z <= 270)
                                ResultText.text = "6만루비 획득!";
                            else if (this.transform.eulerAngles.z > 270 && this.transform.eulerAngles.z <= 315)
                                ResultText.text = "7만루비 획득!";
                            else if (this.transform.eulerAngles.z > 315 && this.transform.eulerAngles.z <= 360)
                                ResultText.text = "8만루비 획득!";
                        }



                        HaveResult = false;
                    }
                }
            }
            transform.Rotate(0, 0, this.SpinSpeed);

        }
    }

  
    public void RouletteBut()
    {
        if (CanPressBut)
        {
            PressBut = !PressBut;
            HaveResult = true;
        }

    }

    public void RequestAnswer()
    {
        if(SpinSpeed>0)
        {
            RouletteBut();
        }
        else
        {
            StartPanel.SetActive(true);
            rouletteGoldCost = (long)((PlayerPrefs.GetInt("_Clicklevel") * 100000) * 1.13);

            rouletteRubyCost = (long)((PlayerPrefs.GetInt("_Clicklevel") * 10) * 1.08);
            if (RouletteType == "Gold")
            {
                StartPanelText.text = "룰렛을 돌리기 위해선 " + rouletteGoldCost + "만큼의 골드가 필요합니다.\n 돌리시겠습니까?";
            }
            else
            {
                StartPanelText.text = "룰렛을 돌리기 위해선 " + rouletteRubyCost + "만큼의 루비가 필요합니다.\n 돌리시겠습니까?";
            }
        }
        
    }

    public void YesBut()
    {
        if (RouletteType == "Gold")
        {
            if (DataController.Instance.Gold >= rouletteGoldCost)
            {
                DataController.Instance.Gold -= (long)rouletteGoldCost;
                RouletteBut();

                StartPanel.SetActive(false);
            }
            else
            {
                StartPanel.SetActive(false);
            }
        }
        else
        {
            if (DataController.Instance.Ruby >= rouletteRubyCost)
            {
                DataController.Instance.Ruby -= (long)rouletteRubyCost;
                RouletteBut();
                StartPanel.SetActive(false);
            }
            else
            {
                StartPanel.SetActive(false);

            }
        }
    }
    public void NoBut()
    {

        StartPanel.SetActive(false);
    }
}