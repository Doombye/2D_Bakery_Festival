using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainClickButton : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void OnMouseDown()
    {
        // 터치 위치
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseClick(mousePos);
        DataController.Instance.Gold += DataController.Instance.ClickGold;
    }

    public void MouseClick(Vector2 pos)
    {
        // 터치 위치에 이팩트 생성해줌.
        Instantiate(prefab, pos, Quaternion.identity);

    }

}
