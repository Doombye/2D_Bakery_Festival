using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class MakeNewName : Singleton<MakeNewName>
{
    [SerializeField] public InputField playerNameInput;
    [SerializeField] public GameObject makeNamePanel;

    // 최초 로그인
    public bool isFirstLogin;
    bool value;

    // Start is called before the first frame update
    void Start()
    {
        isFirstLogin = true;
        value = System.Convert.ToBoolean(PlayerPrefs.GetInt("Panel"));
        PanelOnOff();
        //Debug.Log("시작 값 : " + value);

    }

    // Update is called once per frame
    void Update()
    {
        //value = System.Convert.ToBoolean(PlayerPrefs.GetInt("Panel"));
    }


    public void FirstPanel()
    {
        if (PlayerPrefs.GetInt("Panel") == 1)
        {
            makeNamePanel.SetActive(false);
        }
    }
    public void PanelOnOff()
    {
        //Debug.Log(value);

        if (value == true)
        {
            makeNamePanel.SetActive(false);
        }
        else
        {
            makeNamePanel.SetActive(true);
        }
    }
}
