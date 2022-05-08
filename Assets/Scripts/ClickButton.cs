using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void OnMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseClick(mousePos);
        DataController.Instance.Gold += DataController.Instance.ClickGold;
    }

    public void MouseClick(Vector2 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);

    }

}
