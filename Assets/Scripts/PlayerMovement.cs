using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool LookRight = true;

    public float Speed;
    Rigidbody2D rigid;
    DropFoodsPointMng dropfoodMng;

    DropFoodsStartTImers FoodTimer;
    public bool IsMove = false; 
    private void Awake()
    { 
        rigid = GetComponent<Rigidbody2D>();

        if (LookRight)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void Start()
    {
        FoodTimer = GameObject.Find("GameMng").GetComponent<DropFoodsStartTImers>();
        dropfoodMng = GameObject.Find("GameMng").GetComponent<DropFoodsPointMng>();

        StartCoroutine("StartGame");
    }
    IEnumerator StartGame()
    {
        if (FoodTimer.IsStart)
        {
            IsMove = true;
        }
        else
        {

            yield return new WaitForSeconds(0.1f);
            StartCoroutine("StartGame");
        }
    }
    private void FixedUpdate()
    {
        if(!FoodTimer.IsStart)
        {

        }
        else
        {
            if (IsMove)
            {
                if (LookRight)
                {
                    rigid.velocity = new Vector2(Speed * Time.deltaTime, rigid.velocity.y);
                }
                else if (!LookRight)
                {
                    rigid.velocity = new Vector2((-1) * Speed * Time.deltaTime, rigid.velocity.y);
                }
            }
        }
       
       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(FoodTimer.IsStart)
        {
            if (collision.gameObject.tag == "Food1")
            {
                Destroy(collision.gameObject);
                dropfoodMng.GetFirstBread();
            }
            //2가 크로아상
            if (collision.gameObject.tag == "Food2")
            {
                Destroy(collision.gameObject);
                dropfoodMng.GetSecondBread();
            }
            //오타로 3을 못붙여서 3이 상한 빵
            if (collision.gameObject.tag == "Food")
            {
                Destroy(collision.gameObject);
                dropfoodMng.GetThirdBread();
            }

        }
        else
        {
            if (collision.gameObject.tag == "Food1")
            {
                Destroy(collision.gameObject); 
            }
            //2가 크로아상
            if (collision.gameObject.tag == "Food2")
            {
                Destroy(collision.gameObject); 
            }
            //오타로 3을 못붙여서 3이 상한 빵
            if (collision.gameObject.tag == "Food")
            {
                Destroy(collision.gameObject); 
            }
        }
    
    }
    public void FlipBut()
    {
        //Debug.Log("DDDDDD");
        LookRight = !LookRight;
        if (LookRight)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
            //Debug.Log("왼쪽");
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            //Debug.Log("오른쪽");

        }
    }
}
