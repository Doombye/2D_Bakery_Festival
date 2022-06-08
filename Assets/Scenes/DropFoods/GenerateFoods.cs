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
    //[SerializeField]
    //GameObject Food2;
    //[SerializeField]
    //GameObject Food3;
    //[SerializeField]
    //GameObject Food4; 
    void Start()
    {
        StartCoroutine("Food1Timer");
    } 
    
    IEnumerator Food1Timer()
    {

        yield return new WaitForSeconds(1f);
        if(Food1Time >3)
        Food1Time++;
        else
        {
            Food1Time = 0;
            StartCoroutine("Food1Timer");
            int xPos = Random.Range(20, 1900);
            Debug.Log(xPos);
            Instantiate(Food1, new Vector3(xPos, DropYPosition.position.y, 0), Quaternion.identity,GameObject.Find("Canvas").transform);
        }

    }

 
}
