using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
    [SerializeField] Text userName;
    [SerializeField] Text goldText;
    [SerializeField] Text rubyText;
    [SerializeField] Text goldPerSecText;
    [SerializeField] CanvasRenderer panel;

    int persecGold;

    private void Start()
    {
        //OnPanel();   
    }

    private void Update()
    {
        persecGold = DataController.Instance.GetGoldPerSec();
        goldText.text = string.Format("{0:#,###0}", DataController.Instance.Gold) + "$";
        userName.text = PlayerPrefs.GetString("Name").ToString();
        rubyText.text = string.Format("{0:#,###0}", DataController.Instance.Ruby);

        
        
        if(panel.gameObject.activeSelf == true)
        {
            goldPerSecText.text = string.Format("{0:#,###0}", persecGold) + "/s";  
        }
    }

    void OnPanel()
    {
        panel.gameObject.SetActive(true);
        panel.SetAlpha(0f);
        Invoke("OffPanel", 0.5f);
    }


    void OffPanel()
    {
        panel.gameObject.SetActive(false);
    }




    /*
    private string[] goldunit = new string[] { "", "만", "억", "경", "해", "자", "양", "가", "구", "간" };
    private string GetGoldUnit()
    {
        // 자를 단위
        int GoldcutUnit = 4;

        long gold = DataController.Instance.Gold;
        // 단위마다 자른 골드 저장
        List<int> numList = new List<int>();

        // 만 단위마다 자르기
        int CutGold = (int)Mathf.Pow(10, GoldcutUnit);

        do
        {
            // 단위로 자른 골드를 리스트에 저장
            //numList.Add((int)gold % CutGold);
            // 만단위 줄이기.
            //gold /= CutGold;
        }
        while (gold >= 1);  // 1보다 크면 반복.

        //단위랑 조합될 문자열
        string UnitGold = "";

        단위당 잘려진 만큼 반복
        for (int i = 0; i < numList.Count; i++)
        {
            UnitGold = numList[i] + goldunit[i] + UnitGold;
        }

        return UnitGold;
    }

    
    private string GetClickGoldUnit()
    {
        // 자를 단위
        int GoldcutUnit = 4;

        long gold = DataController.Instance.ClickGold;
        // 단위마다 자른 골드 저장
        List<int> numList = new List<int>();

        // 만 단위마다 자르기
        int CutGold = (int)Mathf.Pow(10, GoldcutUnit);

        do
        {
            // 단위로 자른 골드를 리스트에 저장
            numList.Add((int)gold % CutGold);
            // 만단위 줄이기.
            gold /= CutGold;
        }
        while (gold >= 1);  // 1보다 크면 반복.

        // 단위랑 조합될 문자열
        string UnitGold = "";

        // 단위당 잘려진 만큼 반복
        for (int i = 0; i < numList.Count; i++)
        {
            UnitGold = numList[i] + goldunit[i] + UnitGold;
        }

        return UnitGold;
    }
    */
}
