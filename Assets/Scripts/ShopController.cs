using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : Singleton<ShopController>
{
    // 현재 상점이 몇개열려있는지 알기위한 함수
    public int ShopLevels;
    //상점 집어넣을 배열     
    [Header("Shops")]
    public GameObject[] Shops = new GameObject[5];
    public GameObject[] ShopsTrigger = new GameObject[5];
    public GameObject[] ShopsSign = new GameObject[5];
    public GameObject[] ShopsCharacter = new GameObject[5];
    public GameObject[] ShopsPanels = new GameObject[5];
    [Header("CookieShop")]
    //CookieShop이 가질 내용
    public int CookieLevel = 0;
    public int CookieSellPrice = 0;
    [Header("DonutShop")]
    //donutShop이 가질 내용
    public int DonutLevel = 0;
    public int DonutSellPrice = 0;
    [Header("PieShop")]
    //PieShop이 가질 내용
    public int PieLevel = 0;
    public int PieSellPrice = 0;
    [Header("MelonShop")]
    //MelonShop이 가질 내용
    public int MelonLevel = 0;
    public int MelonSellPrice = 0;
    [Header("CakeShop")]
    //CakeShop이 가질 내용
    public int CakeLevel = 0;
    public int CakeSellPrice = 0;

    private void Start()
    {
        LoadShopButton();
        ShopSetActives();
    }

    // 데이터 저장
    public void SaveShopButton()
    { 
        PlayerPrefs.SetInt("ShopLevel", ShopLevels);         // 구매 레벨 저장.
        PlayerPrefs.SetInt("CookieLevel", CookieLevel);
        PlayerPrefs.SetInt("CookieSellPrice", CookieSellPrice);
        PlayerPrefs.SetInt("DonutLevel", DonutLevel);
        PlayerPrefs.SetInt("DonutSellPrice", DonutSellPrice);
        PlayerPrefs.SetInt("PieLevel", PieLevel);
        PlayerPrefs.SetInt("PieSellPrice", PieSellPrice);
        PlayerPrefs.SetInt("MelonLevel", MelonLevel);
        PlayerPrefs.SetInt("MelonSellPrice", MelonSellPrice);
        PlayerPrefs.SetInt("CakeLevel", CakeLevel);
        PlayerPrefs.SetInt("CakeSellPrice", CakeSellPrice);
    }

    // 데이터 불러오기
    public void LoadShopButton()
    {
        ShopLevels = PlayerPrefs.GetInt("ShopLevel");     // 레벨 불러오기 
        CookieLevel = PlayerPrefs.GetInt("CookieLevel");
        CookieSellPrice = PlayerPrefs.GetInt("CookieSellPrice");
        DonutLevel = PlayerPrefs.GetInt("DonutLevel");
        DonutSellPrice = PlayerPrefs.GetInt("DonutSellPrice");
        PieLevel = PlayerPrefs.GetInt("PieLevel");
        PieSellPrice = PlayerPrefs.GetInt("PieSellPrice");
        MelonLevel = PlayerPrefs.GetInt("MelonLevel");
        MelonSellPrice = PlayerPrefs.GetInt("MelonSellPrice");
        CakeLevel = PlayerPrefs.GetInt("CakeLevel");
        CakeSellPrice = PlayerPrefs.GetInt("CakeSellPrice");
    }

    void ShopSetActives()
    {
        for (int i = 0; i < ShopLevels; i++)
        { 
            Shops[i].SetActive(true);
            ShopsTrigger[i].SetActive(true); 
            ShopsSign[i].SetActive(true);
            ShopsCharacter[i].SetActive(true);
        }
        for (int j = 0; j < ShopLevels; j++)
        { 
            if(j>3)
            {
                break;
            }
            ShopsPanels[j].SetActive(false);
            
            
        }
    }

    public void CookieUpgradeBut()
    {
        if (CookieLevel == 0)
        {
            if (DataController.Instance.Gold >= 20000)
            {
                CookieLevel++;
                CookieSellPrice = 1000;
                DataController.Instance.Gold -= 20000;
                ShopLevels++;
                ShopSetActives();
                SaveShopButton();
            }
        }
        else
        {
            int NeedMoney = 1000 * (int)Mathf.Pow(1.07f , CookieLevel);
            if (DataController.Instance.Gold > NeedMoney)
            {
                CookieLevel++;
                DataController.Instance.Gold -= NeedMoney;
                CookieSellPrice = 1000 * (int)Mathf.Pow(1.0501f, CookieLevel); 
                SaveShopButton();
            }
        }
    }
    public void DonutUpgradeBut()
    {
        if (DonutLevel == 0)
        {
            if (DataController.Instance.Gold >= 70000)
            {
                DonutLevel++;
                DonutSellPrice = 1000;
                DataController.Instance.Gold -= 70000;
                ShopLevels++;
                SaveShopButton(); 
                ShopSetActives();
            }
        }
        else
        {
            int NeedMoney = 2000 * (int)Mathf.Pow(1.079f, DonutLevel);
            if (DataController.Instance.Gold > NeedMoney)
            {
                DonutLevel++;
                DataController.Instance.Gold -= NeedMoney;
                DonutSellPrice = 1000 * (int)Mathf.Pow(1.0503f, DonutLevel);
                SaveShopButton();
            }
        }
    }
    public void PieUpgradeBut()
    {
        if (PieLevel == 0)
        {
            if (DataController.Instance.Gold >= 100000)
            {
                PieLevel++;
                PieSellPrice = 3000;
                DataController.Instance.Gold -= 100000;
                ShopLevels++;
                SaveShopButton(); 
                ShopSetActives();
            }
        }
        else
        {
            int NeedMoney = 1000 * (int)Mathf.Pow(1.0868f, PieLevel);
            if (DataController.Instance.Gold > NeedMoney)
            {
                PieLevel++;
                DataController.Instance.Gold -= NeedMoney;
                PieSellPrice = 1000 * (int)Mathf.Pow(1.0503f, PieLevel);
                SaveShopButton();
            }
        }
    }
    public void MelonUpgradeBut()
    {
        if (MelonLevel == 0)
        {
            if (DataController.Instance.Gold >= 20000)
            {
                MelonLevel++;
                MelonSellPrice = 1000;
                DataController.Instance.Gold -= 20000;
                ShopLevels++;
                SaveShopButton();
                ShopSetActives();
            }
        }
        else
        {
            int NeedMoney = 4000 * (int)Mathf.Pow(1.0909f, MelonLevel);
            if (DataController.Instance.Gold > NeedMoney)
            {
                MelonLevel++;
                DataController.Instance.Gold -= NeedMoney;
                CookieSellPrice = 1000 * (int)Mathf.Pow(1.0503f, MelonLevel);
                SaveShopButton();
            }
        }
    }
    public void CakeUpgradeBut()
    {
        if (CakeLevel == 0)
        {
            if (DataController.Instance.Gold >= 20000)
            {
                CakeLevel++;
                CakeSellPrice = 1000;
                DataController.Instance.Gold -= 20000;
                ShopLevels++;
                SaveShopButton(); 
                ShopSetActives();
            }
        }
        else
        {
            int NeedMoney = 4000 * (int)Mathf.Pow(1.09f, CakeLevel);
            if (DataController.Instance.Gold > NeedMoney)
            {
                CakeSellPrice++;
                DataController.Instance.Gold -= NeedMoney;
                CookieSellPrice = 1000 * (int)Mathf.Pow(1.0503f, CakeLevel);
                SaveShopButton();
            }
        }
    }

   
}
