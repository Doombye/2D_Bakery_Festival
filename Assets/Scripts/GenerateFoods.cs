using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFoods : MonoBehaviour
{
    [SerializeField]
    Transform DropYPosition;
    [SerializeField]
    GameObject Food1;
    float Food1Time = 0; 

    [SerializeField]
    GameObject Food2; 

    float Food2Time = 0;
    [SerializeField]
    GameObject Food3;

    float Food3Time = 0; 

    int width = Screen.width;
    public bool Generatenow = false;
    DropFoodsStartTImers FoodTimer;

    void Start()
    {
        FoodTimer = GameObject.Find("GameMng").GetComponent<DropFoodsStartTImers>();
        StartCoroutine("StartGame"); 
        
    }
    private void Update()
    {
        if(!FoodTimer.IsStart)
        {
            Generatenow = false;
            StopCoroutine("Food1Timer1");
            StopCoroutine("Food1Timer2");
            StopCoroutine("Food1Timer3");
        }
    }



    IEnumerator StartGame()
    {
        if(FoodTimer.IsStart)
        {
            Generatenow = true;
            StopCoroutine("StartGame");
            StartCoroutine("Food1Timer");
            StartCoroutine("Food2Timer");
            StartCoroutine("Food3Timer");
            
        }
        else
        {

            yield return new WaitForSeconds(0.1f);
            StartCoroutine("StartGame");
        }
    }
    IEnumerator Food1Timer()
    {
        if(Generatenow)
        {
            yield return new WaitForSeconds(0.1f);
            if (Food1Time <= 1)
            {
                Food1Time += 0.3f;
                StartCoroutine("Food1Timer");
            }

            else
            {
                Food1Time = 0;
                int xPos = Random.Range(100, width - 60);
                Debug.Log(xPos);
                Instantiate(Food1, new Vector3(xPos, DropYPosition.position.y, 0), Quaternion.identity, GameObject.Find("FoodsBank").transform);

                StartCoroutine("Food1Timer");
            }
        }
       

    }
    IEnumerator Food2Timer()
    {
        if (Generatenow)
        {
            yield return new WaitForSeconds(0.1f);
            if (Food2Time < 3)
            {
                Food2Time += 0.1f;
                StartCoroutine("Food2Timer");
            }
            else
            {
                Food2Time = 0;
                int xPos = Random.Range(100, width - 60);
                Debug.Log(xPos);
                Instantiate(Food2, new Vector3(xPos, DropYPosition.position.y, 0), Quaternion.identity, GameObject.Find("FoodsBank").transform);
                StartCoroutine("Food2Timer");
            }
        }


    }
    IEnumerator Food3Timer()
    {
        if (Generatenow)
        {
            yield return new WaitForSeconds(0.1f);
            if (Food3Time < 6)
            {
                Food3Time += 0.1f;
                StartCoroutine("Food3Timer");
            }

            else
            {
                Food3Time = 0;
                int xPos = Random.Range(100, width - 100);
                Debug.Log(xPos);
                Instantiate(Food3, new Vector3(xPos, DropYPosition.position.y, 0), Quaternion.identity, GameObject.Find("FoodsBank").transform);
                StartCoroutine("Food3Timer");
            }
        }
    }
}
