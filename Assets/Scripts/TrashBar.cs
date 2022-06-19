using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBar : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food1")
        {
            Destroy(collision.gameObject);
        }
    }
}
