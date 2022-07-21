using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickUpButton : Singleton<ClickUpButton>
{
    [SerializeField] Text upgradText;
 
    public string upgradeName;          // 업그레이드 이름

    public int upgradeGold;             // 업그레이드 되는 골드량
    //[SerializeField] public int startupgradeGold;    // 처음 업그레이드 골드

    public int currentCost;         // 현재 업그레이드 비용
    [SerializeField] public int startcurrentCost;    // 처음 업그레이드 비용

    public int level = 1;               // 업그레이드 횟수

    [SerializeField] public float upgradePowf;  // 업그레이드 마다 늘어나는 골드 배율 값
    [SerializeField] public float costPow ;     // 업그레이드 마다 추가되는 비용 배율 값

    public void Start()
    {   
        DataController.Instance.LoadUpgradeButton(this);
        

        UpdateUI();
    }

    public void Update()
    {
        UpdateUI();
    }

    // 구매버튼 클릭시 불리는 함수
    public void BuyUpgreade()
    {
        if (DataController.Instance.Gold >= currentCost)
        {
            DataController.Instance.Gold -= currentCost;
            level++;
            DataController.Instance.ClickGold += upgradeGold;

            UpdateUpgrad();
            UpdateUI();
            DataController.Instance.SaveUpgradeButton(this);
           //Debug.Log("BuyUpgreade111111111111111111111111111111");
        }
    }
    public void UpdateUpgrad()
    {
        upgradeGold =  1;
        currentCost = Mathf.FloorToInt(currentCost * costPow);
        //upgradeGold = startupgradeGold * (int)Mathf.Pow(upgradePow, level);
    }

    public void UpdateUI()
    {

        upgradText.text = upgradeName +
            string.Format("\nPrice :{0:#,###0}", currentCost) +
            "\nLv : " + string.Format("{0:#,###0}", level) +
            "\nGoldClick : " + string.Format("{0:#,###0}", DataController.Instance.ClickGold);


        //Debug.Log("클릭당 골드 : " + DataController.Instance.ClickGold);
        //Debug.Log("판매금액 : " + currentCost);
        //Debug.Log("Lv : " + level);
    }
    
}
