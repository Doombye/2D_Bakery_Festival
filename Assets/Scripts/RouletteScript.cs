using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RouletteScript : MonoBehaviour
{
    public string RouletteType;
    public bool IsSpin = false;
    //��� �����°�
    public bool PressBut = false;
    //��ư�� ������ �ִ� �����ΰ� 
    public bool CanPressBut = true;

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
        rouletteGoldCost = (long)((PlayerPrefs.GetInt("_Clicklevel") * 100000) * 1.13);
        rouletteRubyCost = (long)((PlayerPrefs.GetInt("_Clicklevel") * 10) * 1.08);

    }
    void Update()
    {
        if(RouletteType == "Ruby")
        {
            Debug.Log(RouletteType);
            RubyRoulette();
        }

        if(RouletteType == "Gold")
        {
            Debug.Log(RouletteType);
            GoldRoulette();
        }
    }

    public void RubyRoulette()
    {
        Debug.Log("���귿 ����");
        if (DataController.Instance.Ruby >= rouletteRubyCost)
        {
            DataController.Instance.Ruby -= (long)rouletteRubyCost;
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
                            Debug.Log(transform.eulerAngles);
                            ResultPanel.SetActive(true);

                            RouletteSong.SecondSong();
                            if (RouletteType == "Ruby")
                            {
                                if (this.transform.eulerAngles.z > 0 && this.transform.eulerAngles.z <= 45)
                                    ResultText.text = "1����� ȹ��!";
                                else if (this.transform.eulerAngles.z > 45 && this.transform.eulerAngles.z <= 90)
                                    ResultText.text = "2����� ȹ��!";
                                else if (this.transform.eulerAngles.z > 90 && this.transform.eulerAngles.z <= 135)
                                    ResultText.text = "3����� ȹ��!";
                                else if (this.transform.eulerAngles.z > 135 && this.transform.eulerAngles.z <= 180)
                                    ResultText.text = "4����� ȹ��!";
                                else if (this.transform.eulerAngles.z > 180 && this.transform.eulerAngles.z <= 225)
                                    ResultText.text = "5����� ȹ��!";
                                else if (this.transform.eulerAngles.z > 225 && this.transform.eulerAngles.z <= 270)
                                    ResultText.text = "6����� ȹ��!";
                                else if (this.transform.eulerAngles.z > 270 && this.transform.eulerAngles.z <= 315)
                                    ResultText.text = "7����� ȹ��!";
                                else if (this.transform.eulerAngles.z > 315 && this.transform.eulerAngles.z <= 360)
                                    ResultText.text = "8����� ȹ��!";
                            }
                            HaveResult = false;

                        }
                    }
                }
                transform.Rotate(0, 0, this.SpinSpeed);

            }
        }
    }

    public void GoldRoulette()
    {
        Debug.Log("���귿 ����");

        if (DataController.Instance.Gold >= rouletteGoldCost)
        {
            DataController.Instance.Gold -= (long)rouletteGoldCost;

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
                        RouletteSong.SecondSong();
                        if (RouletteType == "Gold")
                        {
                            if (this.transform.eulerAngles.z > 0 && this.transform.eulerAngles.z <= 45)
                            {
                                DataController.Instance.Gold += 100000;
                                ResultText.text = "1����� ȹ��!";
                            }
                            else if (this.transform.eulerAngles.z > 45 && this.transform.eulerAngles.z <= 90)
                                ResultText.text = "2����� ȹ��!";
                            else if (this.transform.eulerAngles.z > 90 && this.transform.eulerAngles.z <= 135)
                                ResultText.text = "3����� ȹ��!";
                            else if (this.transform.eulerAngles.z > 135 && this.transform.eulerAngles.z <= 180)
                                ResultText.text = "4����� ȹ��!";
                            else if (this.transform.eulerAngles.z > 180 && this.transform.eulerAngles.z <= 225)
                                ResultText.text = "5����� ȹ��!";
                            else if (this.transform.eulerAngles.z > 225 && this.transform.eulerAngles.z <= 270)
                                ResultText.text = "6����� ȹ��!";
                            else if (this.transform.eulerAngles.z > 270 && this.transform.eulerAngles.z <= 315)
                                ResultText.text = "7����� ȹ��!";
                            else if (this.transform.eulerAngles.z > 315 && this.transform.eulerAngles.z <= 360)
                                ResultText.text = "8����� ȹ��!";
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
}