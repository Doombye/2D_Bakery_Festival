using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using TMPro;
public class MiniGameUiMng : MonoBehaviour
{
    // Start is called before the first frame update
    string Name;
    string Gold;
    string ruby;
    int perGold;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI RubyText;
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI PerGoldText;


    void Start()
    {
        perGold = DataController.Instance.GetGoldPerSec();
        GoldText.text = string.Format("{0:#,###0}", DataController.Instance.Gold) + "$";
        NameText.text = PlayerPrefs.GetString("Name").ToString();
        RubyText.text = string.Format("{0:#,###0}", DataController.Instance.Ruby);
        PerGoldText.text = perGold.ToString(); 
    }

    public void SetStartBut()
    {
        int DropFoodsStart = 0;
        DropFoodsStart = 1;
        PlayerPrefs.SetInt("DropFoodsStart",DropFoodsStart);
    }
}
