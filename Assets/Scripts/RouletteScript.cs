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

    private bool HaveResult = false;
    public float SpinSpeed = 0f;
    public Text ResultText;
    public GameObject ResultPanel;
    void Update()
    {
        if (CanPressBut)
        {
            if (PressBut)
            {
                this.SpinSpeed = 15;
            }
            else
            {
                if (SpinSpeed > 0.01)
                {
                    CanPressBut = false;
                    this.SpinSpeed *= 0.997f;
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
}