using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Object : MonoBehaviour
{
    public GameObject destructionEffect;
    
    private Animator anim;


    public float Distance()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 diff = transform.position - player.position;
        float distance = (float)Math.Abs(diff.x);
        return distance;
    }
    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void Death()
    {
        Instantiate(destructionEffect, transform.position, destructionEffect.transform.rotation);
        anim.Play("Destroy");
    }
}
