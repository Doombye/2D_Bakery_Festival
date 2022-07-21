using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_NPC : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float Destorytimer;


    Transform EndPos;
    public bool HaveTarget = false;
    Vector3 TargetPos;

    Rigidbody2D rigid;

    float lifeTimer;
     

    int ReturnToNew = 99999;
    int ReturnTempNum = 99991;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        EndPos = GameObject.FindGameObjectWithTag("R_End").GetComponent<Transform>();
        
    }

    void Update()
    {
        if(!HaveTarget) 
        SetTarget(EndPos.transform.position);

        MoveToTarget(TargetPos);
         
        lifeTimer += Time.deltaTime;
        if (this.transform.position.y == EndPos.transform.position.y)
        {
            SetTarget(EndPos.transform.position);
        }
    }

    void SetTarget(Vector3 N)
    {
        HaveTarget = true;
        TargetPos = N;
    }
    void MoveToTarget(Vector3 N)
    {
        if (Vector2.Distance(transform.position, N) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, N, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("R_End"))
        {
            Destroy(gameObject);
        }
        
    }

    //∆ƒ¿Ã 1 ƒÌ≈∞ 2 ƒ…¿Ã≈© 3 µµ≥” 4 ∏·∑– 5
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PieShopBox" && ReturnTempNum != 1)
        {
            ReturnTempNum = 1;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("PieShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("PieShopStay1").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 1;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("PieShopStay2").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 2;
                        break;
                    case 99:
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }
        }
        if (collision.gameObject.name == "CookieShopBox" && ReturnTempNum != 2)
        {
            ReturnTempNum = 2;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("CookieShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("CookieShopStay1").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 3;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("CookieShopStay2").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 4;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        if (collision.gameObject.name == "CakeShopBox" && ReturnTempNum != 3)
        {
            //Debug.Log("CakeShopCollision");
            ReturnTempNum = 3;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("CakeShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("CakeShopStay1").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 5;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("CakeShopStay2").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 6;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        if (collision.gameObject.name == "DonutShopBox" && ReturnTempNum != 4)
        {
            ReturnTempNum = 4;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("DonutShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("DonutShopStay1").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 7;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("DonutShopStay2").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 8;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        if (collision.gameObject.name == "MelonShopBox" && ReturnTempNum != 5)
        {
            ReturnTempNum = 5;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("MelonShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("MelonShopStay1").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 9;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("MelonShopStay2").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 10;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        if (collision.gameObject.CompareTag("StartTimer"))
        { 
            StartCoroutine("ReturnTimer");
        }
    }

    int CheckEmptyPlace(string name)
    {
        if (name == "PieShop")
        {
            if (GameObject.Find("PieShopStay1").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("PieShopStay1").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("PieShopStay2").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("PieShopStay2").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }
          
            else
            {
                return 1111;
            }    
        }
        if (name == "CookieShop")
        {
            if (GameObject.Find("CookieShopStay1").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CookieShopStay1").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("CookieShopStay2").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CookieShopStay2").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }
          
            else
            {
                return 1111;
            }
        } 
        if (name == "CakeShop")
        {
            if (GameObject.Find("CakeShopStay1").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CakeShopStay1").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("CakeShopStay2").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CakeShopStay2").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }

            else
            {
                return 1111;
            }
        } 
        if (name == "DonutShop")
        {
            if (GameObject.Find("DonutShopStay1").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("DonutShopStay1").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("DonutShopStay2").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("DonutShopStay2").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }

            else
            {
                return 1111;
            }
        } 
        if (name == "MelonShop")
        {
            if (GameObject.Find("MelonShopStay1").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("MelonShopStay1").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("MelonShopStay2").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("MelonShopStay2").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }

            else
            {
                return 1111;
            }
        }
        return 99;
    }

    IEnumerator ReturnTimer()
    {
        
        yield return new WaitForSeconds(3f);
         
            SetTarget(new Vector3(this.transform.position.x, EndPos.position.y, 0));

            switch (ReturnToNew)
            {
                case 1:
                    GameObject.Find("PieShopStay1").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f); 
                    SetTarget(EndPos.transform.position);  
                break;

                case 2:
                    GameObject.Find("PieShopStay2").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f);
                 SetTarget(EndPos.transform.position);
                break;

                case 3:
                    GameObject.Find("CookieShopStay1").GetComponent<EmptyPlace>().IsEmpty = true;
                  yield return new WaitForSeconds(1.5f);
                   SetTarget(EndPos.transform.position); 
                break;

                case 4:
                    GameObject.Find("CookieShopStay2").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f);
                    SetTarget(EndPos.transform.position);
                break;

                case 5:
                    GameObject.Find("CakeShopStay1").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f);
                 SetTarget(EndPos.transform.position);
                 break;

                case 6:
                    GameObject.Find("CakeShopStay2").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f);
                    SetTarget(EndPos.transform.position);
                    break;

                case 7:
                    GameObject.Find("DonutShopStay1").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f);
                    SetTarget(EndPos.transform.position);
                    break;

                case 8:
                    GameObject.Find("DonutShopStay2").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f);
                    SetTarget(EndPos.transform.position);
                    break;

                case 9:
                    GameObject.Find("MelonShopStay1").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f);
                    SetTarget(EndPos.transform.position);
                    break;

                case 10:
                    GameObject.Find("MelonShopStay2").GetComponent<EmptyPlace>().IsEmpty = true;
                    yield return new WaitForSeconds(1.5f);
                    SetTarget(EndPos.transform.position);
                    break;
               
                default:
                    break;
            }
            StopCoroutine("ReturnTimer");
       

    }
}
