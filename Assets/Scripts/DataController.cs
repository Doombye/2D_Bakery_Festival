using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;               // dataTime 사용하기 위해
using System.Text;          // 다른 객체로 변환하기위해

public class DataController : Singleton<DataController>
{
    // 초당 수익 버튼 저장 배열
    public PerSecUpButton[] goldPerSecButtons;
    int sumValue;

    void Start()
    {
        //StartCoroutine(AddGoldLoop());
        // 게임에 접속하지 않아도 시간이 흐른만큼 골드를 더해준다. (최대 3일 까지)
        Gold += PlayerPrefs.GetInt("_isGoldPerSecSum") * Mathf.Clamp(AfterTime(), 0, 260000);
        InvokeRepeating("UpdateLastPlayDate", 0f, 10f);         // 10초마다 플레이 시간 저장.
    }

    private void Update()
    {
        Debug.Log("초당 수익 : " + PlayerPrefs.GetInt("_isGoldPerSecSum") + " 원");

        goldPerSecButtons = FindObjectsOfType<PerSecUpButton>();
        Debug.Log("초당 수익 함수 : " + GetGoldPerSec());
    }

    // 마지막 플레이 날짜
    DateTime GetLastPlayDate()
    {
        // 시간을 저장하지 않았다면
        if (!PlayerPrefs.HasKey("Time"))
        {
            return DateTime.Now;    // 현재시간을 가져온다.
        }

        string timeInString = PlayerPrefs.GetString("Time");    // 저장해둔 종료 시간을 가져온다.
        DateTime time = Convert.ToDateTime(timeInString);       // String 값을 long의 형태로 변환시켜준다.

        return time;
    }

    // 마지막 플레이 한 시점(시간) 업데이트
    void UpdateLastPlayDate()
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToString());     // 현재 시간을 string으로 저장
    }

    // 얼마동안 게임을 끄고 있었는지 확인하는 함수
    public int AfterTime()
    {
        DateTime currentTime = DateTime.Now;            // 현재시간
        DateTime lastPlayDate = GetLastPlayDate();      // 마지막 게임 종료시간

        TimeSpan span = currentTime - lastPlayDate;     // 게임을 종료하고 흐른시간.

        return (int)span.TotalSeconds;                  // 시간 차이를 초 단위로 변경.
    }

    // 게임 종료시 자동으로 불리는 함수
    private void OnApplicationQuit()
    {
        UpdateLastPlayDate();                           // 게임 종료시 플레이 타임 저장.
        SetGoldPerSec();
    }

    // 현재 골드량
    public long Gold
    {
        get
        {
            // 골드가 저장되어 있는지 확인
            if (!PlayerPrefs.HasKey("Gold"))
            {
                return 0;
            }

            string gold = PlayerPrefs.GetString("Gold");
            // 스트링 골드를 인트로 전달
            return long.Parse(gold);

        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }

    public int ClickGold
    {
        get
        {
            // 저장해둔 값을 키값에 따라 불러오기
            return PlayerPrefs.GetInt("ClickGold", 1);
        }
        set
        {
            // value 값을 저장한다.
            PlayerPrefs.SetInt("ClickGold", value);
        }
    }

    // 업그레이드(클릭당 수익) 버튼데이터 불러오기
    public void LoadUpgradeButton(ClickUpButton clickUpButton)
    {
        string key = clickUpButton.upgradeName;

        // 저장되있는 키값을 이용해서 데이터불러오기
        clickUpButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        clickUpButton.upgradeGold = PlayerPrefs.GetInt(key + "_upgradeGold", clickUpButton.startupgradeGold);
        clickUpButton.currentCost = PlayerPrefs.GetInt(key + "_cost", clickUpButton.startcurrentCost);
    }

    // 업그레이드(클릭당 수익) 버튼 데이터 저장
    public void SaveUpgradeButton(ClickUpButton clickUpButton)
    {
        string key = clickUpButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", clickUpButton.level);                 // 키값(_level)으로 현재 level 을 저장.
        PlayerPrefs.SetInt(key + "_upgradeGold", clickUpButton.upgradeGold);     // 키값(_upgradeGold)으로 현재 upgradeGold 를 저장. (업그레이드시 클릭당 증가비용)
        PlayerPrefs.SetInt(key + "_cost", clickUpButton.currentCost);            // 키값(_cost)으로 현재 currentCost 를 저장. (구매비용)
    }



    // 초당 수익 데이터 불러오기
    public void LoadWorkButton(PerSecUpButton perSecUpButton)
    {
        string key = perSecUpButton.itemName;

        // 저장되있는 키값을 이용해서 데이터불러오기
        perSecUpButton.level = PlayerPrefs.GetInt(key + "_level");
        perSecUpButton.currentCost = PlayerPrefs.GetInt(key + "_cost", perSecUpButton.startCurrentCost);
        perSecUpButton.goldPerCec = PlayerPrefs.GetInt(key + "_goldPerSec", perSecUpButton.startGoldPerSec);

        // isBuy : 구매 여부 확인
        // 아이템이 구매가 되어있다면 1, 아니면 0 으로 구매여부를 확인한 후 불러온다.
        if (PlayerPrefs.GetInt(key + "_isBuy") == 1)
        {
            perSecUpButton.isBuy = true;
        }
        else
        {
            perSecUpButton.isBuy = false;
        }
    }

    // 초당 수익 데이터 저장
    public void SaveWorkButton(PerSecUpButton perSecUpButton)
    {
        string key = perSecUpButton.itemName;

        PlayerPrefs.SetInt(key + "_level", perSecUpButton.level);
        PlayerPrefs.SetInt(key + "_cost", perSecUpButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", perSecUpButton.goldPerCec);

        // isBuy : 구매 여부 확인
        // 아이템이 구매가 되어있다면 1, 아니면 0 으로 구매여부를 확인한 후 저장한다.
        if (perSecUpButton.isBuy == true)
        {
            PlayerPrefs.SetInt(key + "_isBuy", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isBuy", 0);
        }
    }


    // 초당 수익 총 합
    public int GetGoldPerSec()
    {
        // 초당 수익 합
        int sum = 0;

        for (int i = 0; i < goldPerSecButtons.Length; i++)
        {
            if (goldPerSecButtons[i].isBuy == true)                    // workButtons 버튼을 구매 했을 경우에만 goldPerCec 를 더해준다.
                sum += goldPerSecButtons[i].goldPerCec;
        } 
        return sum;
    }
    public void SetGoldPerSec()
    {
        PlayerPrefs.SetInt("_isGoldPerSecSum", GetGoldPerSec());        
    }
}
