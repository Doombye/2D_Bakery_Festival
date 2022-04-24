using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Transform target;
    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("End").GetComponent<Transform>();
    }

    private void Update()
    {
        GoTarget();
    }

    void GoTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
