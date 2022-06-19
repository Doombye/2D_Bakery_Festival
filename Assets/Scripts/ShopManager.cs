using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    
    [SerializeField]GameObject[] shops = new GameObject[4];
    ShopInfo Shop0;
    ShopInfo Shop1;
    ShopInfo Shop2;
    ShopInfo Shop3;


    public bool Shop0Check = false;
    public bool Shop1Check = false;
    public bool Shop2Check = false;
    public bool Shop3Check = false;

    // Start is called before the first frame update
    void Start()
    {
        Shop0 = shops[0].GetComponent<ShopInfo>();
        Shop1 = shops[1].GetComponent<ShopInfo>();
        Shop2 = shops[2].GetComponent<ShopInfo>();
        Shop3 = shops[3].GetComponent<ShopInfo>();
    }

    private void Update()
    {
        Shop0.IsWorking = Shop0Check;
        Shop1.IsWorking = Shop1Check;
        Shop2.IsWorking = Shop2Check;
        Shop3.IsWorking = Shop3Check;
    }

    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("NPC"))
        {
            int RandNum = Random.Range(1, 2);
            if(RandNum == 0){}
            else
            { 
                if (!Shop0.IsWorking && collision.gameObject.GetComponent<NPC>().PositionType == "End")
                {
                    collision.gameObject.GetComponent<NPC>().target = Shop0.gameObject.transform;
                    collision.gameObject.GetComponent<NPC>().PositionType = "Store";
                    Shop0Check = true;
                }
                else if (!Shop1.IsWorking && collision.gameObject.GetComponent<NPC>().PositionType == "End")
                {
                    collision.gameObject.GetComponent<NPC>().target = Shop1.gameObject.transform;
                    collision.gameObject.GetComponent<NPC>().PositionType = "Store";
                    Shop1Check = true;
                }
                else if (!Shop2.IsWorking && collision.gameObject.GetComponent<NPC>().PositionType == "End")
                {
                    collision.gameObject.GetComponent<NPC>().target = Shop2.gameObject.transform;
                    collision.gameObject.GetComponent<NPC>().PositionType = "Store";
                    Shop2Check = true;
                }
                else if (!Shop3.IsWorking && collision.gameObject.GetComponent<NPC>().PositionType == "End")
                {
                    collision.gameObject.GetComponent<NPC>().target = Shop3.gameObject.transform;
                    collision.gameObject.GetComponent<NPC>().PositionType = "Store";
                    Shop3Check = true;
                } 


            }
            
             
        }
    }
    */
}
