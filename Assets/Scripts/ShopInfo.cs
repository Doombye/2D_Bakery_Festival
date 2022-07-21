using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfo :MonoBehaviour 
{
    public bool IsActive = false;
    public bool IsWorking = false;
    [SerializeField] int ShopNum;
    float Timer =1f;


    ShopDataContoller ShopMng;
    GameObject NpcObject;

    [SerializeField]GameObject BackToLine;


    private void Start()
    { 
    }
    private void Update()
    {
        if(IsWorking == true)
        {
            if (Timer > 0)
            {
                //Debug.Log(Timer);
                Timer -= Time.deltaTime;
            }
            else
            {
                switch (ShopNum)
                {
                    case 0:
                        break;
                    default:
                        break;
                }
                Destroy(NpcObject);
                
            } 
        }
       
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("NPC"))
        Timer = 4f;
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            while (true)
            {
                //Debug.Log(Timer + this.gameObject.name);
                Timer -= Time.deltaTime;
                if (Timer < 0)
                {

                    //Debug.Log("TImeOUt" + this.gameObject.name);
                    break;
                }
            }
        }
       
    }

}
