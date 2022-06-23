using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropFoodsPointMng : MonoBehaviour
{
    public Text PointsString;
    public int PointsNum;

    string InputString;
    void Start()
    {
        PointsNum = 0;
    }
 
    public void GetFirstBread()
    {
        PointsNum += 30;
        InputString = PointsNum.ToString();
        PointsString.text = InputString;
    }
    public void GetSecondBread()
    {
        PointsNum += 60; 
        InputString = PointsNum.ToString();
        PointsString.text = InputString;
    }
    public void GetThirdBread()
    {
        if(PointsNum > 0)
        {
            PointsNum -= 100;
            if(PointsNum <0 )
            {
                PointsNum = 0;
            }
            InputString = PointsNum.ToString();
            PointsString.text = InputString;
        } 
    }
}
