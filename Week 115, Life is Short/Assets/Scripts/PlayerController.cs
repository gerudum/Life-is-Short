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
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(movementX * speed, movementY * speed);
        rb.velocity = movement;
    }
}
