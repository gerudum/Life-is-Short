using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Logic : MonoBehaviour
{
    public GameObject trigger;
    public bool toggled;

    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void Activate()
    {
        Debug.Log("Activate!");
        anim.SetBool("isActive", toggled);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Activate();
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Activate();
        }
    }
}
