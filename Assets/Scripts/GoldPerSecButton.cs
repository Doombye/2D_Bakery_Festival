using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPerSecButton : Singleton<GoldPerSecButton>
{
    public string itemName;                 // 아이템 이름
    public int level;                       // 업글 레벨

    [HideInInspector]
    public int currentCost;                 // 초기 구매비용
    public int startCurrentCost = 1;        // 최초 시작비용

    [HideInInspector]
    public int goldPerCec;                  // 초기 초당올라가는 금액
    public int startGoldPerSec = 1;         // 최초 초당올라가는 금액

    public float CostPow = 3.14f;           // 구매비용 증가배율
    public float upgradePow = 1.14f;        // 업그레이드시 올라가는 초당 골드 증가배율

    [HideInInspector]
    public bool isBuy = false;              // 아이템 구매여부

    // 아이템 구매시
    public void BuyItem()
    {
        if (DataController.Instance.Gold >= currentCost)
        {
            isBuy = true;
            DataController.Instance.Gold -= (currentCost);
            level++;

            UpdateItem();

            // 구매한 아이템 저장
            DataController.Instance.SaveWorkButton(this);
        }
    }

    // 1초마다 반복해서 골드를 증가
    IEnumerator AddGoldLoop()
    {
        while (true)
        {
            if (isBuy)
            {
                DataController.Instance.Gold += (goldPerCec);
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerCec = goldPerCec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);      // 레벨에 따른 골드증가.
        currentCost = startCurrentCost * (int)Mathf.Pow(CostPow, level);                    // 레벨에 따른 구매비용 증가.
    }
}
