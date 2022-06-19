using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointMng : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        { 
            Destroy(collision.gameObject);
        }
    }
 

}
