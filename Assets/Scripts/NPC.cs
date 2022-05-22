using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float deleteTimer;

    Transform target;
    Rigidbody2D rigid;
    Collider2D col;

    float timer;
    

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("End").GetComponent<Transform>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        GoTarget();
        DeleteNPC();
    }

    void GoTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    void DeleteNPC()
    {
        timer += Time.deltaTime;
        if(timer >= deleteTimer)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}
