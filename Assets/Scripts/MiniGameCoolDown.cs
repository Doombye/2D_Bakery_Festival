using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameCoolDown : MonoBehaviour
{

    public GameObject DropFoodsButs;
    public Image DropFoodsCoolDownImage;
    public Text DropFoodsCoolTimeText;

    public float DropFoodsCoolTime = 180;
    bool CanMiniGame = true;
    string Temps;
    // Update is callwed once per frame
    void Update()
    {
        //이미 게임을 하고 돌아온 상태라면 
        if(PlayerPrefs.GetInt("DropFoodsStart") == 1)
        {
            DropFoodsCoolDownImage.fillAmount = 1;
            PlayerPrefs.SetInt("DropFoodsStart", 0);
            CanMiniGame = false;
            DropFoodsCoolTime = 180;
            StartCoroutine("CoolDownStart");
        }
        if(CanMiniGame == false)
        {
            DropFoodsButs.SetActive(true);
        }
        else
        {
            DropFoodsButs.SetActive(false);
        }
    }

    IEnumerator CoolDownStart()
    {
        yield return new WaitForSeconds(1f);
        if (DropFoodsCoolTime > 0)
        {
            DropFoodsCoolTime -= 1;
            DropFoodsCoolTimeText.text = DropFoodsCoolTime.ToString();
            StartCoroutine("CoolDownStart");
        }
        else
        {
            CanMiniGame = true;
            DropFoodsButs.SetActive(false);

        }
        DropFoodsCoolDownImage.fillAmount -= 0.0055555556f;
    }
}
