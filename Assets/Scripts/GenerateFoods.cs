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
    //[SerializeField]
    //GameObject Food4; 
    void Start()
    {
        StartCoroutine("Food1Timer");
        StartCoroutine("Food2Timer");
        StartCoroutine("Food3Timer");
    }

    IEnumerator Food1Timer()
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
            int xPos = Random.Range(20, 1900);
            Debug.Log(xPos);
            Instantiate(Food1, new Vector3(xPos, DropYPosition.position.y, 0), Quaternion.identity, GameObject.Find("Canvas").transform);

            StartCoroutine("Food1Timer");
        }

    }
    IEnumerator Food2Timer()
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
            int xPos = Random.Range(20, 1900);
            Debug.Log(xPos);
            Instantiate(Food2, new Vector3(xPos, DropYPosition.position.y, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            StartCoroutine("Food2Timer");
        }

    }
    IEnumerator Food3Timer()
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
            int xPos = Random.Range(20, 1900);
            Debug.Log(xPos);
            Instantiate(Food3, new Vector3(xPos, DropYPosition.position.y, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            StartCoroutine("Food3Timer");
        }

    }
}
