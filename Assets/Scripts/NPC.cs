using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //페스티벌이벤트가 시작되었는지 알기위한 Bool
    public bool IsFestivalNow = false;

    [SerializeField] float Destorytimer;
    //위에서 스폰된 NPC가 돌아가기위한 Y좌표를 받기위한 transform

    [SerializeField] float percent; // 캐릭터 이동 비율 퍼센트
    [SerializeField] Vector3 TargetPos;
    [SerializeField] int NpcType = 0;

    Transform UpNpcPos;
    Transform EndPos;

    //가만히 멈췄을 때를 대비
    public Vector3 TempPos;

    public bool HaveTarget = false;
    float DoubleMoveSpeed;
    float DefaultmoveSpeed;
    float moveSpeed;
    int width = Screen.width;       // 가로 해상도


    //상점에 다가간후 다시 들어갈수있는 곳이라는 것을 나타내기 위한 함수
    int ReturnToNew = 99999;
    int ReturnTempNum = 99991;

    //Festival을 컨트롤 하기위한 소환
    FestivalManager festivalMng;

    private void Start()
    {
        festivalMng = GameObject.Find("DataController").GetComponent<FestivalManager>();
        //EndPos 안에 끝지점을 정해줄 Transform 을 집어넣는다
        EndPos = GameObject.FindGameObjectWithTag("L_End").GetComponent<Transform>();
        //R_end가 tag중에 사용안되고 남는 상황이 되어 재사용겸 사용
        UpNpcPos = GameObject.FindGameObjectWithTag("R_End").GetComponent<Transform>();

        DefaultmoveSpeed = (width * percent) / 100;
        DoubleMoveSpeed = (width * percent) / 40;

        TempPos = this.transform.position;

        StartCoroutine("PushToEnd");
    }

    void Update()
    {
        TempPos = this.transform.position;


        //축제이벤트가 실행이 되면 모든것을 멈추고 오른쪽으로 빠르게 이동 
        IsFestivalNow = GameObject.Find("DataController").GetComponent<FestivalManager>().IsFestival;
        if (IsFestivalNow)
        {

            if(ShopController.Instance.ShopLevels == 0)
            {
                goto Set6;
            }
            else if(ShopController.Instance.ShopLevels == 1)
            {
                goto Set5;
            }
            else if (ShopController.Instance.ShopLevels == 2)
            {
                goto Set4;
            }
            else if (ShopController.Instance.ShopLevels == 3)
            {
                goto Set3;
            }
            else if (ShopController.Instance.ShopLevels == 4)
            {
                goto Set2;
            }
            else if (ShopController.Instance.ShopLevels == 5)
            {
                goto Set1;
            }
        //축제가 되었을때 다시 비어있는 상태라고 설정 해주는 것.
Set1:
            GameObject.Find("CakeShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("CakeShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("CakeShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;
           
Set2:
            GameObject.Find("MelonShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("MelonShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("MelonShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;
           
Set3:
            GameObject.Find("PieShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("PieShopStay4").GetComponent<EmptyPlace>().IsEmpty = true; 
            GameObject.Find("PieShopStay5").GetComponent<EmptyPlace>().IsEmpty = true; 
Set4: 
            GameObject.Find("DonutShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("DonutShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("DonutShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;

Set5:
            GameObject.Find("CookieShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("CookieShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
            GameObject.Find("CookieShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;
Set6:



            SetTarget(EndPos.transform.position);
            MoveToTarget(TargetPos);
            moveSpeed = DoubleMoveSpeed;
        }
        else
        {
            moveSpeed = DefaultmoveSpeed;
            //만약 타겟을 가지지 않았다면 EndPos위치로 타겟을 설정
            if (!HaveTarget)
                SetTarget(EndPos.transform.position);
            //
            MoveToTarget(TargetPos);

            if (NpcType == 2)
            {
                if (this.transform.position.y == EndPos.transform.position.y)
                {
                    SetTarget(EndPos.transform.position);
                }
            }
            else
            {
                if (this.transform.position.y == UpNpcPos.transform.position.y)
                {
                    SetTarget(EndPos.transform.position);
                }
            }
        }


    }
    // 해당 Vector3 위치로 타겟을 지정해 주는 역활
    void SetTarget(Vector3 N)
    {
        HaveTarget = true;
        TargetPos = N;
    }

    //받은 좌표 위치로 이동시켜주는 함수
    void MoveToTarget(Vector3 N)
    {
        if (Vector2.Distance(transform.position, N) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, N, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("L_End"))
        {
            festivalMng.DeletedNpc();
            Destroy(this.gameObject);
        }

    }

    //파이 1 쿠키 2 케이크 3 도넛 4 멜론 5
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //아랫줄에서 소환되는지 위에서 소환되는지를 구분하기 위한 NpcType
        if (collision.gameObject.name == "NpcSpawner1")
        {
            NpcType = 1;
        }
        if (collision.gameObject.name == "NpcSpawner2")
        {
            NpcType = 2;
        }
        /*
        아래의 코드는 고유번호의 차이말고는 똑같은 코드이기에 맨위의 파이상점의 코드에 상세 코드를 기록해놓았습니다. 
        */

        //파이상점에 들어가는 박스트리거에 맞았을때 그리고 이미 그 가게를 들어갔던 NPC가 아니라면 해당 IF문 실행 
        if (collision.gameObject.name == "PieShopBox" && ReturnTempNum != 1)
        {
            //이 상점의 고유번호 이 번호를 가지고 있어야 올라갔던 상점에 다시 들어가지 않게 한다 
            ReturnTempNum = 1;
            //이 가게를 들어갈지 말지 정하는 확률 (1,2)일때 1이면 들어가고 2일땐 들어가지 않는다
            int RandN = Random.Range(1, 4);
            //목적지인 가게위치 를 Transform 형태로 받기 위한 함수
            Transform T1;
            if (RandN == 1)
            {
                //해당 가게에 비어있는 공간이 있는지를 물어보는 함수실행 후 return 되어 오는 숫자가 있다면 Switch문으로 넘어간다
                int ShopTargetNum = CheckEmptyPlace("PieShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        //T1이라는 함수에 남아있는 자리의 위치를 받아온다.
                        T1 = GameObject.FindGameObjectWithTag("PieShopStay3").GetComponent<Transform>();
                        //Target을 T1이라는 함수로 바꾼다
                        SetTarget(T1.transform.position);
                        //그 자리가 가진 고유 번호 
                        ReturnToNew = 1;
                        break;
                    case 1:
                        //T1이라는 함수에 남아있는 자리의 위치를 받아온다.
                        T1 = GameObject.FindGameObjectWithTag("PieShopStay4").GetComponent<Transform>();
                        //Target을 T1이라는 함수로 바꾼다
                        SetTarget(T1.transform.position);
                        //그 자리가 가진 고유 번호 
                        ReturnToNew = 2;
                        break;
                    case 2:
                        //T1이라는 함수에 남아있는 자리의 위치를 받아온다.
                        T1 = GameObject.FindGameObjectWithTag("PieShopStay5").GetComponent<Transform>();
                        //Target을 T1이라는 함수로 바꾼다
                        SetTarget(T1.transform.position);
                        //그 자리가 가진 고유 번호 
                        ReturnToNew = 11;
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
        //쿠키상점에 들어가는 박스트리거에 맞았을때 그리고 이미 그 가게를 들어갔던 NPC가 아니라면 해당 IF문 실행 
        if (collision.gameObject.name == "CookieShopBox" && ReturnTempNum != 2)
        {
            ReturnTempNum = 2;
            int RandN = Random.Range(1, 4);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("CookieShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("CookieShopStay3").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 3;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("CookieShopStay4").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 4;
                        break;
                    case 2:
                        T1 = GameObject.FindGameObjectWithTag("CookieShopStay5").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 12;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        //케이크상점에 들어가는 박스트리거에 맞았을때 그리고 이미 그 가게를 들어갔던 NPC가 아니라면 해당 IF문 실행 
        if (collision.gameObject.name == "CakeShopBox" && ReturnTempNum != 3)
        {
            ReturnTempNum = 3;
            int RandN = Random.Range(1, 4);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("CakeShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("CakeShopStay3").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 5;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("CakeShopStay4").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 6;
                        break;
                    case 2:
                        T1 = GameObject.FindGameObjectWithTag("CakeShopStay5").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 13;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        //도넛상점에 들어가는 박스트리거에 맞았을때 그리고 이미 그 가게를 들어갔던 NPC가 아니라면 해당 IF문 실행 
        if (collision.gameObject.name == "DonutShopBox" && ReturnTempNum != 4)
        {
            ReturnTempNum = 4;
            int RandN = Random.Range(1, 4);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("DonutShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("DonutShopStay3").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 7;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("DonutShopStay4").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 8;
                        break;

                    case 2:
                        T1 = GameObject.FindGameObjectWithTag("DonutShopStay5").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 14;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        //멜론상점에 들어가는 박스트리거에 맞았을때 그리고 이미 그 가게를 들어갔던 NPC가 아니라면 해당 IF문 실행 
        if (collision.gameObject.name == "MelonShopBox" && ReturnTempNum != 5)
        {
            ReturnTempNum = 5;
            int RandN = Random.Range(1, 4);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("MelonShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("MelonShopStay3").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 9;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("MelonShopStay4").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 10;
                        break;
                    case 2:
                        T1 = GameObject.FindGameObjectWithTag("MelonShopStay5").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 15;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }

        //상점에 들어간 후 카운트 들어가는 코루틴 실행
        if (collision.gameObject.CompareTag("StartTimer"))
        {
            StartCoroutine("ReturnTimer");
        }
    }

    int CheckEmptyPlace(string name)
    {
        /*
        아래의 코드는 고유번호의 차이말고는 똑같은 코드이기에 맨위의 파이상점의 코드에 상세 코드를 기록해놓았습니다. 
        */

        //받아온 string이 파이상점이라면 
        if (name == "PieShop")
        {
            //비어있는 자리가 있는지를 확인하고
            if (GameObject.Find("PieShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                //있다면 이젠 비어있지않다라고 설정후
                GameObject.Find("PieShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                //0을 리턴시켜준다 이후 스위치문에서 사용
                return 0;
            }
            else if (GameObject.Find("PieShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                //있다면 이젠 비어있지않다라고 설정후
                GameObject.Find("PieShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                //1을 리턴시켜준다 이후 스위치문에서 사용
                return 1;
            }
            else if (GameObject.Find("PieShopStay5").GetComponent<EmptyPlace>().IsEmpty)
            {
                //있다면 이젠 비어있지않다라고 설정후
                GameObject.Find("PieShopStay5").GetComponent<EmptyPlace>().IsEmpty = false;
                //1을 리턴시켜준다 이후 스위치문에서 사용
                return 2;
            }
            //비어있지않다면 1111리턴
            else
            {
                return 1111;
            }
        }
        //받아온 string이 쿠키상점이라면 
        if (name == "CookieShop")
        {
            if (GameObject.Find("CookieShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CookieShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("CookieShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CookieShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }
            else if (GameObject.Find("CookieShopStay5").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CookieShopStay5").GetComponent<EmptyPlace>().IsEmpty = false;
                return 2;
            }
            else
            {
                return 1111;
            }
        }
        //받아온 string이 케이크상점이라면 
        if (name == "CakeShop")
        {
            if (GameObject.Find("CakeShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CakeShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("CakeShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CakeShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }
            else if (GameObject.Find("CakeShopStay5").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CakeShopStay5").GetComponent<EmptyPlace>().IsEmpty = false;
                return 2;
            }
            else
            {
                return 1111;
            }
        }
        //받아온 string이 도넛상점이라면 
        if (name == "DonutShop")
        {
            if (GameObject.Find("DonutShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("DonutShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("DonutShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("DonutShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }
            else if (GameObject.Find("DonutShopStay5").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("DonutShopStay5").GetComponent<EmptyPlace>().IsEmpty = false;
                return 2;
            }
            else
            {
                return 1111;
            }
        }
        //받아온 string이 멜론상점이라면 
        if (name == "MelonShop")
        {
            if (GameObject.Find("MelonShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("MelonShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("MelonShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("MelonShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }
            else if (GameObject.Find("MelonShopStay5").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("MelonShopStay5").GetComponent<EmptyPlace>().IsEmpty = false;
                return 2;
            }
            else
            {
                return 1111;
            }
        }
        //받아온 string이 파이상점이라면 
        return 99;
    }

    IEnumerator ReturnTimer()
    {
        //3초 가게에서 기다린후 
        yield return new WaitForSeconds(3f);
        if (!IsFestivalNow)
        {
            switch (ReturnToNew)
            {
                case 1:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("PieSellPrice");
                    break;
                case 2:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("PieSellPrice");
                    break;
                case 3:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CookieSellPrice");
                    break;
                case 4:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CookieSellPrice");
                    break;
                case 5:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CakeSellPrice");
                    break;
                case 6:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CakeSellPrice");
                    break;
                case 7:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("DonutSellPrice");
                    break;
                case 8:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("DonutSellPrice");
                    break;
                case 9:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CakeSellPrice");
                    break;
                case 10:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CakeSellPrice");
                    break;
                case 11:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("PieSellPrice");
                    break;
                case 12:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CookieSellPrice");
                    break;
                case 13:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CakeSellPrice");
                    break;
                case 14:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("DonutSellPrice");
                    break;
                case 15:
                    DataController.Instance.Gold += PlayerPrefs.GetInt("CakeSellPrice");
                    break;
                default:
                    break;

            }
        }
        
        
        //아래에서 소환된 아이라면 그대로 아래까지 타겟설정
        if (NpcType == 2)
        {
            SetTarget(new Vector3(this.transform.position.x, EndPos.position.y, 0));
        }
        //위에서 소환된 아이면 위에 스폰 장소까지 타겟설정
        else
        {

            SetTarget(new Vector3(this.transform.position.x, UpNpcPos.position.y, 0));
        }
        //다 쓴자리는 다시 가게에 들어갈수있도록 True 형태로 전환.
        switch (ReturnToNew)
        {
            case 1:
                GameObject.Find("PieShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 2:
                GameObject.Find("PieShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 3:
                GameObject.Find("CookieShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 4:
                GameObject.Find("CookieShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 5:
                GameObject.Find("CakeShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 6:
                GameObject.Find("CakeShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 7:
                GameObject.Find("DonutShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 8:
                GameObject.Find("DonutShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 9:
                GameObject.Find("MelonShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 10:
                GameObject.Find("MelonShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 11:
                GameObject.Find("PieShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 12:
                GameObject.Find("CookieShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 13:
                GameObject.Find("CakeShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 14:
                GameObject.Find("DonutShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 15:
                GameObject.Find("MelonShopStay5").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            default:
                break;
        }
        StopCoroutine("ReturnTimer");


    }
    IEnumerator PushToEnd()
    {
        yield return new WaitForSeconds(0.2f);
        if (this.transform.position.y <= 330)
        {
            //Debug.Log("왜 안움직이니");
            if (this.transform.position == TempPos)
            {
                //Debug.Log("움직여줘");

                SetTarget(EndPos.transform.position);
            }
        }
        StartCoroutine("PushToEnd");
    }
}
