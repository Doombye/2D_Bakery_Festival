using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : Singleton<ShopController>
{
    // ���� ���� ����..
    public int buyLevel;

    //���� ����..
    public int currentLevel;

    // ���� ���� Ȯ��.
    public bool isBuy = false;

    // ���ź��
    public int BuyCost; 
    

    // ������ ����
    public void SaveShopButton()
    {
        PlayerPrefs.SetInt("ShopBuyCost", BuyCost);         // ���籸�ź�� ����
        PlayerPrefs.SetInt("ShopLevel", currentLevel);      // ���� ���� ����.
        PlayerPrefs.SetInt("ShopBuyLevel", buyLevel);       // ���� ���� ����.

        // ���������� 1, �ƴϸ� 0
        if (isBuy == true)
            PlayerPrefs.SetInt("isBuy", 1);
        else
            PlayerPrefs.SetInt("isBuy", 0);
    }

    // ������ �ҷ�����
    public void LoadShopButton()
    {
        BuyCost = PlayerPrefs.GetInt("ShopBuyCost");        // ��� �ҷ�����
        currentLevel = PlayerPrefs.GetInt("ShopLevel");     // ���� �ҷ�����
        buyLevel = PlayerPrefs.GetInt("ShopBuyLevel");      // ���ŷ��� �ҷ�����.

        if (PlayerPrefs.GetInt("isBuy") == 1)
            isBuy = true;
        else
            isBuy = false;
    }



}
