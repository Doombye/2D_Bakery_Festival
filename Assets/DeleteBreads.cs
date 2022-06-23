using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBreads : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
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
