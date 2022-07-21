using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RouletteScript : MonoBehaviour
{
    public string RouletteType;
    public bool IsSpin = false;
    //¹æ±Ý ´­·¶´Â°¡
    public bool PressBut = false;
    //¹öÆ°À» ´©¸¦¼ö ÀÖ´Â »óÅÂÀÎ°¡ 
    public bool CanPressBut = true;

    //½ÃÀÛÇÏ±âÀü¿¡ ÀÇ»ç¿©ºÎ ¹°¾îº¼ ÆÐ³Ö
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
                                ResultText.text = "1¸¸°ñµå È¹µæ!";
                            else if (this.transform.eulerAngles.z > 45 && this.transform.eulerAngles.z <= 90)
                                ResultText.text = "2¸¸°ñµå È¹µæ!";
                            else if (this.transform.eulerAngles.z > 90 && this.transform.eulerAngles.z <= 135)
                                ResultText.text = "3¸¸°ñµå È¹µæ!";
                            else if (this.transform.eulerAngles.z > 135 && this.transform.eulerAngles.z <= 180)
                                ResultText.text = "4¸¸°ñµå È¹µæ!";
                            else if (this.transform.eulerAngles.z > 180 && this.transform.eulerAngles.z <= 225)
                                ResultText.text = "5¸¸°ñµå È¹µæ!";
                            else if (this.transform.eulerAngles.z > 225 && this.transform.eulerAngles.z <= 270)
                                ResultText.text = "6¸¸°ñµå È¹µæ!";
                            else if (this.transform.eulerAngles.z > 270 && this.transform.eulerAngles.z <= 315)
                                ResultText.text = "7¸¸°ñµå È¹µæ!";
                            else if (this.transform.eulerAngles.z > 315 && this.transform.eulerAngles.z <= 360)
                                ResultText.text = "8¸¸°ñµå È¹µæ!";
                        }
                        else
                        {
                            if (this.transform.eulerAngles.z > 0 && this.transform.eulerAngles.z <= 45)
                                ResultText.text = "1¸¸·çºñ È¹µæ!";
                            else if (this.transform.eulerAngles.z > 45 && this.transform.eulerAngles.z <= 90)
                                ResultText.text = "2¸¸·çºñ È¹µæ!";
                            else if (this.transform.eulerAngles.z > 90 && this.transform.eulerAngles.z <= 135)
                                ResultText.text = "3¸¸·çºñ È¹µæ!";
                            else if (this.transform.eulerAngles.z > 135 && this.transform.eulerAngles.z <= 180)
                                ResultText.text = "4¸¸·çºñ È¹µæ!";
                            else if (this.transform.eulerAngles.z > 180 && this.transform.eulerAngles.z <= 225)
                                ResultText.text = "5¸¸·çºñ È¹µæ!";
                            else if (this.transform.eulerAngles.z > 225 && this.transform.eulerAngles.z <= 270)
                                ResultText.text = "6¸¸·çºñ È¹µæ!";
                            else if (this.transform.eulerAngles.z > 270 && this.transform.eulerAngles.z <= 315)
                                ResultText.text = "7¸¸·çºñ È¹µæ!";
                            else if (this.transform.eulerAngles.z > 315 && this.transform.eulerAngles.z <= 360)
                                ResultText.text = "8¸¸·çºñ È¹µæ!";
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
                StartPanelText.text = "·ê·¿À» µ¹¸®±â À§ÇØ¼± " + rouletteGoldCost + "¸¸Å­ÀÇ °ñµå°¡ ÇÊ¿äÇÕ´Ï´Ù.\n µ¹¸®½Ã°Ú½À´Ï±î?";
            }
            else
            {
                StartPanelText.text = "·ê·¿À» µ¹¸®±â À§ÇØ¼± " + rouletteRubyCost + "¸¸Å­ÀÇ ·çºñ°¡ ÇÊ¿äÇÕ´Ï´Ù.\n µ¹¸®½Ã°Ú½À´Ï±î?";
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