using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : Singleton<ShopController>
{
    // 구매 가능 레벨..
    public int buyLevel;

    //현재 레벨..
    public int currentLevel;

    // 구매 여부 확인.
    public bool isBuy = false;

    // 구매비용
    public int BuyCost; 
    

    // 데이터 저장
    public void SaveShopButton()
    {
        PlayerPrefs.SetInt("ShopBuyCost", BuyCost);         // 현재구매비용 저장
        PlayerPrefs.SetInt("ShopLevel", currentLevel);      // 현재 레벨 저장.
        PlayerPrefs.SetInt("ShopBuyLevel", buyLevel);       // 구매 레벨 저장.

        // 구매했으면 1, 아니면 0
        if (isBuy == true)
            PlayerPrefs.SetInt("isBuy", 1);
        else
            PlayerPrefs.SetInt("isBuy", 0);
    }

    // 데이터 불러오기
    public void LoadShopButton()
    {
        BuyCost = PlayerPrefs.GetInt("ShopBuyCost");        // 비용 불러오기
        currentLevel = PlayerPrefs.GetInt("ShopLevel");     // 레벨 불러오기
        buyLevel = PlayerPrefs.GetInt("ShopBuyLevel");      // 구매레벨 불러오기.

        if (PlayerPrefs.GetInt("isBuy") == 1)
            isBuy = true;
        else
            isBuy = false;
    }



}
