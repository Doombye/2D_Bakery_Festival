using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_NPC : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float Destorytimer;


    Transform EndPos;
    Rigidbody2D rigid;

    float lifeTimer;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        EndPos = GameObject.FindGameObjectWithTag("R_End").GetComponent<Transform>();

    }

    void Update()
    {
        GoTarget();
        Destroy();
        lifeTimer += Time.deltaTime;
    }

    void GoTarget()
    {
        if (Vector2.Distance(transform.position, EndPos.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, EndPos.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("R_End"))
        {
            Destroy(gameObject);
        }
    }

    void Destroy()
    {
        if (lifeTimer >= Destorytimer)
        {
            Destroy(gameObject);
        }
    }
}
