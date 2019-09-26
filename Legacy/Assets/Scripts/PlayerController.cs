using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
  
    public float speed;

    //Caching
    private Rigidbody2D rb;
    public void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dir = mousePos - transform.position;
        dir.z = 0;
        dir = dir.normalized;

        if (Input.GetMouseButton(0))
        {
            rb.velocity = dir * speed;
        } else
        {
            rb.velocity = new Vector2(0, 0);
        }
        
    }
}
