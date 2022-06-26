using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;               // dataTime »ç¿ëÇÏ±â À§ÇØ
using System.Text;          // ´Ù¸¥ °´Ã¼·Î º¯È¯ÇÏ±âÀ§ÇØ
using System.Text.RegularExpressions;

public class DataController : Singleton<DataController>
{
    // ÃÊ´ç ¼öÀÍ ¹öÆ° ÀúÀå ¹è¿­
    public PerSecUpButton[] goldPerSecButtons;
    int sumValue;

    void Start()
    {
        //StartCoroutine(AddGoldLoop());
        // °ÔÀÓ¿¡ Á¢¼ÓÇÏÁö ¾Ê¾Æµµ ½Ã°£ÀÌ Èå¸¥¸¸Å­ °ñµå¸¦ ´õÇØÁØ´Ù. (ÃÖ´ë 3ÀÏ ±îÁö)
        Gold += PlayerPrefs.GetInt("_isGoldPerSecSum") * Mathf.Clamp(AfterTime(), 0, 260000);
        InvokeRepeating("UpdateLastPlayDate", 0f, 10f);         // 10ÃÊ¸¶´Ù ÇÃ·¹ÀÌ ½Ã°£ ÀúÀå.
    }

    private void Update()
    {
        Debug.Log("ÃÊ´ç ¼öÀÍ : " + PlayerPrefs.GetInt("_isGoldPerSecSum") + " ¿ø");

        goldPerSecButtons = FindObjectsOfType<PerSecUpButton>();
        Debug.Log("ÃÊ´ç ¼öÀÍ ÇÔ¼ö : " + GetGoldPerSec());
    }

    // ¸¶Áö¸· ÇÃ·¹ÀÌ ³¯Â¥
    DateTime GetLastPlayDate()
    {
        // ½Ã°£À» ÀúÀåÇÏÁö ¾Ê¾Ò´Ù¸é
        if (!PlayerPrefs.HasKey("Time"))
        {
            return DateTime.Now;    // ÇöÀç½Ã°£À» °¡Á®¿Â´Ù.
        }

        string timeInString = PlayerPrefs.GetString("Time");    // ÀúÀåÇØµĞ Á¾·á ½Ã°£À» °¡Á®¿Â´Ù.
        DateTime time = Convert.ToDateTime(timeInString);       // String °ªÀ» longÀÇ ÇüÅÂ·Î º¯È¯½ÃÄÑÁØ´Ù.

        return time;
    }

    // ¸¶Áö¸· ÇÃ·¹ÀÌ ÇÑ ½ÃÁ¡(½Ã°£) ¾÷µ¥ÀÌÆ®
    void UpdateLastPlayDate()
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToString());     // ÇöÀç ½Ã°£À» stringÀ¸·Î ÀúÀå
    }

    // ¾ó¸¶µ¿¾È °ÔÀÓÀ» ²ô°í ÀÖ¾ú´ÂÁö È®ÀÎÇÏ´Â ÇÔ¼ö
    public int AfterTime()
    {
        DateTime currentTime = DateTime.Now;            // ÇöÀç½Ã°£
        DateTime lastPlayDate = GetLastPlayDate();      // ¸¶Áö¸· °ÔÀÓ Á¾·á½Ã°£

        TimeSpan span = currentTime - lastPlayDate;     // °ÔÀÓÀ» Á¾·áÇÏ°í Èå¸¥½Ã°£.

        return (int)span.TotalSeconds;                  // ½Ã°£ Â÷ÀÌ¸¦ ÃÊ ´ÜÀ§·Î º¯°æ.
    }

    // °ÔÀÓ Á¾·á½Ã ÀÚµ¿À¸·Î ºÒ¸®´Â ÇÔ¼ö
    private void OnApplicationQuit()
    {
        UpdateLastPlayDate();                           // °ÔÀÓ Á¾·á½Ã ÇÃ·¹ÀÌ Å¸ÀÓ ÀúÀå.
        SetGoldPerSec();
    }

    // ÇöÀç °ñµå·®
    public long Gold
    {
        get
        {
            // °ñµå°¡ ÀúÀåµÇ¾î ÀÖ´ÂÁö È®ÀÎ
            if (!PlayerPrefs.HasKey("Gold"))
            {
                return 0;
            }

            string gold = PlayerPrefs.GetString("Gold");
            // ½ºÆ®¸µ °ñµå¸¦ ÀÎÆ®·Î Àü´Ş
            return long.Parse(gold);
        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }

    // ÇöÀç ·çºñ
    public long Ruby
    {
        get
        {
            // ·çºñ°¡ ÀúÀåµÇ¾î ÀÖ´ÂÁö È®ÀÎ
            if (!PlayerPrefs.HasKey("Ruby"))
            {
                return 0;
            }

            string Luby = PlayerPrefs.GetString("Ruby");
            // ·çÇÇ Àü´Ş.
            return long.Parse(Luby);
        }
        set
        {
            PlayerPrefs.SetString("Luby", value.ToString());
        }
    }

    public int ClickGold
    {
        get
        {
            // ÀúÀåÇØµĞ °ªÀ» Å°°ª¿¡ µû¶ó ºÒ·¯¿À±â
            return PlayerPrefs.GetInt("ClickGold", 1);
        }
        set
        {
            // value °ªÀ» ÀúÀåÇÑ´Ù.
            PlayerPrefs.SetInt("ClickGold", value);
        }
    }

    // ¾÷±×·¹ÀÌµå(Å¬¸¯´ç ¼öÀÍ) ¹öÆ°µ¥ÀÌÅÍ ºÒ·¯¿À±â
    public void LoadUpgradeButton(ClickUpButton clickUpButton)
    {
        string key = clickUpButton.upgradeName;

        // ÀúÀåµÇÀÖ´Â Å°°ªÀ» ÀÌ¿ëÇØ¼­ µ¥ÀÌÅÍºÒ·¯¿À±â
        clickUpButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        clickUpButton.upgradeGold = PlayerPrefs.GetInt(key + "_upgradeGold", clickUpButton.startupgradeGold);
        clickUpButton.currentCost = PlayerPrefs.GetInt(key + "_cost", clickUpButton.startcurrentCost);
    }

    // ¾÷±×·¹ÀÌµå(Å¬¸¯´ç ¼öÀÍ) ¹öÆ° µ¥ÀÌÅÍ ÀúÀå
    public void SaveUpgradeButton(ClickUpButton clickUpButton)
    {
        string key = clickUpButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", clickUpButton.level);                 // Å°°ª(_level)À¸·Î ÇöÀç level À» ÀúÀå.
        PlayerPrefs.SetInt(key + "_upgradeGold", clickUpButton.upgradeGold);     // Å°°ª(_upgradeGold)À¸·Î ÇöÀç upgradeGold ¸¦ ÀúÀå. (¾÷±×·¹ÀÌµå½Ã Å¬¸¯´ç Áõ°¡ºñ¿ë)
        PlayerPrefs.SetInt(key + "_cost", clickUpButton.currentCost);            // Å°°ª(_cost)À¸·Î ÇöÀç currentCost ¸¦ ÀúÀå. (±¸¸Åºñ¿ë)
    }

    // ÃÊ´ç ¼öÀÍ µ¥ÀÌÅÍ ºÒ·¯¿À±â
    public void LoadWorkButton(PerSecUpButton perSecUpButton)
    {
        string key = perSecUpButton.itemName;

        // ÀúÀåµÇÀÖ´Â Å°°ªÀ» ÀÌ¿ëÇØ¼­ µ¥ÀÌÅÍºÒ·¯¿À±â
        perSecUpButton.level = PlayerPrefs.GetInt(key + "_level");
        perSecUpButton.currentCost = PlayerPrefs.GetInt(key + "_cost", perSecUpButton.startCurrentCost);
        perSecUpButton.goldPerCec = PlayerPrefs.GetInt(key + "_goldPerSec", perSecUpButton.startGoldPerSec);

        // isBuy : ±¸¸Å ¿©ºÎ È®ÀÎ
        // ¾ÆÀÌÅÛÀÌ ±¸¸Å°¡ µÇ¾îÀÖ´Ù¸é 1, ¾Æ´Ï¸é 0 À¸·Î ±¸¸Å¿©ºÎ¸¦ È®ÀÎÇÑ ÈÄ ºÒ·¯¿Â´Ù.
        if (PlayerPrefs.GetInt(key + "_isBuy") == 1)
        {
            perSecUpButton.isBuy = true;
        }
        else
        {
            perSecUpButton.isBuy = false;
        }
    }

    // ÃÊ´ç ¼öÀÍ µ¥ÀÌÅÍ ÀúÀå
    public void SaveWorkButton(PerSecUpButton perSecUpButton)
    {
        string key = perSecUpButton.itemName;

        PlayerPrefs.SetInt(key + "_level", perSecUpButton.level);
        PlayerPrefs.SetInt(key + "_cost", perSecUpButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", perSecUpButton.goldPerCec);

        // isBuy : ±¸¸Å ¿©ºÎ È®ÀÎ
        // ¾ÆÀÌÅÛÀÌ ±¸¸Å°¡ µÇ¾îÀÖ´Ù¸é 1, ¾Æ´Ï¸é 0 À¸·Î ±¸¸Å¿©ºÎ¸¦ È®ÀÎÇÑ ÈÄ ÀúÀåÇÑ´Ù.
        if (perSecUpButton.isBuy == true)
        {
            PlayerPrefs.SetInt(key + "_isBuy", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isBuy", 0);
        }
    }

    // ÃÊ´ç ¼öÀÍ ÃÑ ÇÕ
    public int GetGoldPerSec()
    {
        // ÃÊ´ç ¼öÀÍ ÇÕ
        int sum = 0;

        for (int i = 0; i < goldPerSecButtons.Length; i++)
        {
            if (goldPerSecButtons[i].isBuy == true)                    // workButtons ¹öÆ°À» ±¸¸Å ÇßÀ» °æ¿ì¿¡¸¸ goldPerCec ¸¦ ´õÇØÁØ´Ù.
                sum += goldPerSecButtons[i].goldPerCec;
        } 
        return sum;
    }
    public void SetGoldPerSec()
    {
        PlayerPrefs.SetInt("_isGoldPerSecSum", GetGoldPerSec());        
    }


    // Á¤±ÔÈ­·Î Æ¯Á¤ ¹®ÀÚ·Î¸¸ ´Ğ³×ÀÓÀ» ¸¸µé ¼ö ÀÖ°Ô ÇÑ´Ù.
    public bool CheckName()
    {
        return Regex.IsMatch(MakeNewName.Instance.playerNameInput.text, "^[0-9a-zA-Z°¡-ÆR]*$");
    }

    // ÀÌ¸§ ÀúÀå
    public void SaveName()
    {

        MakeNewName.Instance.isFirstLogin = false;
        PlayerPrefs.SetString("Name", MakeNewName.Instance.playerNameInput.text);
        if(PlayerPrefs.GetString("Name").Length > 0)
        {
            PlayerPrefs.SetInt("Panel", 1);
            MakeNewName.Instance.FirstPanel();
        }
        else
        {
            Debug.Log("´Ğ³×ÀÓÀ» ÀÔ·ÂÇÏ¼¼¿ä");
            return;
        }
    }

    // ÀÌ¸§ ºÒ·¯¿À±â
    public void LoadName()
    {
        MakeNewName.Instance.playerNameInput.text = PlayerPrefs.GetString("Name");
    }
}
