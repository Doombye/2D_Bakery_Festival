using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainClickButton : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    Vector2 creatPonit;

    public void OnMouseDown()
    {
        // 터치 위치
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        creatPonit = Input.mousePosition;
        
        DataController.Instance.Gold += DataController.Instance.ClickGold;
        MouseClick();
    }

    public void MouseClick()
    {
        // 터치 위치에 이팩트 생성해줌.
        Instantiate(prefab, creatPonit, Quaternion.identity, GameObject.Find("Canvas").transform);

    }

}
