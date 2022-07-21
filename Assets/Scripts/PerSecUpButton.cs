using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerSecUpButton : Singleton<PerSecUpButton>
{
    [SerializeField] Text itemText;   
    public string itemName;
    public int level;

    [HideInInspector]
    public int currentCost;
    public int startCurrentCost = 1;

    [HideInInspector]
    public int goldPerSec;
    public int startGoldPerSec = 1;

    public float CostPow = 3.14f;
    public float upgradePow = 1.14f;

    [HideInInspector]
    public bool isBuy = false;        // 아이템 구매여부

    private void Start()
    {
        DataController.Instance.LoadPerSButton(this);        // 기존 아이템 정보 불러오기
        StartCoroutine(AddGoldLoop());
        UpdataUI();
    }
    private void Update()
    {
        UpdataUI();
    }

    // 아이템 구매시
    public void BuyItem()
    {
        //Debug.Log(DataController.Instance.Ruby);

        if(isBuy != true)
        {
            if(DataController.Instance.Ruby >= currentCost)
            {
                DataController.Instance.Ruby -= currentCost;
                level++;
                isBuy = true;
                CostUpdate();
                DataController.Instance.SavePerSButton(this);
            }
        }
        else
        {
            if (DataController.Instance.Ruby >= currentCost)
            {
                DataController.Instance.Ruby -= currentCost;

                //Debug.Log(DataController.Instance.Ruby);

                level++;
                UpdatePerSec();
                CostUpdate();
                UpdataUI();

                DataController.Instance.SavePerSButton(this);
                // 구매한 아이템 저장

                //Debug.Log(DataController.Instance.Ruby);
            }
        }        
    }

    // 1초마다 반복해서 골드를 증가

 
    IEnumerator AddGoldLoop()
    {
        while (true)
        {
            if (isBuy)
            {
                DataController.Instance.Gold += (goldPerSec);
                //Debug.Log("1초당 코루틴 재생중");
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdatePerSec()
    {
        goldPerSec  =  Mathf.FloorToInt(goldPerSec * upgradePow);
    }
    public void CostUpdate()
    {
        currentCost = Mathf.FloorToInt(currentCost * CostPow);

    }


    public void UpdataUI()
    {
        itemText.text = itemName + "\nLv : " + string.Format("{0:#,###0}", level) +
            "\nPrice : " + string.Format("{0:#,###0}", currentCost) +
            "\nWagePerSec :" + string.Format("{0:#,###0}", goldPerSec);
    }
}
