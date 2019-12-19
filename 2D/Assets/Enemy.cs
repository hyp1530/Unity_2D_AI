using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   [Header("移動速度"),Range(0,50)]

    public float speed = 1.5f;

    [Header("攻擊傷害"), Range(0, 100)]

    public Transform checkPoint;

    private Rigidbody2D r2d;

    public float damage = 20;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();   
    }

    private void Move()
    {
        r2d.AddForce(new Vector2(-speed, 0));
    }
    private void Track()
    {

    }
}

