using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;               // dataTime 사용하기 위해
using System.Text;          // 다른 객체로 변환하기위해

public class DataController : Singleton<DataController>
{


    void Start()
    {
        // 게임에 접속하지 않아도 시간이 흐른만큼 골드를 더해준다. (최대 3일 까지)
        Gold += PlayerPrefs.GetInt("_isGoldPerSecSum") * Mathf.Clamp(AfterTime(), 0, 260000);       
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
        UpdateLastPlayDate();       // 게임 종료시 플레이 타임 저장.
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



}
