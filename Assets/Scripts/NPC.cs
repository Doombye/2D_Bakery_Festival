using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    public Transform target;
    public string PositionType = "End";
    Transform EndPos;
    Rigidbody2D rigid; 



    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); 
        EndPos = GameObject.FindGameObjectWithTag("End").GetComponent<Transform>();
        target = EndPos;
    }

    void Update()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("TargetToEnd"))
        { 
            target = EndPos;
        }
    }
}
