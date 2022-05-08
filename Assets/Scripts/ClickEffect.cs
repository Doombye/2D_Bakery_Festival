using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] float lifeTime;

    float time;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > lifeTime)
        {
            Destroy(gameObject);
            time = 0.0f;
        }
    }
}
