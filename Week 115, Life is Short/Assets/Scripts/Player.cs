using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 3f;
    public float healthTimer = 1f;

    public Animator pulse;
    public Text healthDisplay;
    public GameObject death;

    private GameManager gm;
    private Animator anim;
    private Rigidbody2D rb;
    public void Start()
    {
        anim = GetComponent<Animator>();
        gm = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
        healthDisplay = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        pulse = GameObject.FindGameObjectWithTag("Pulse").GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        //Only lose health while moving
        if(rb.velocity.magnitude != 0)
        {
            healthTimer -= Time.deltaTime;
        }
       
        //Take damage when the timer is up
        if(healthTimer <= 0)
        {
            TakeDamage(1);
            healthTimer = 1f;
        }
    }


    //Taking damage, die if health hits 0
    public void TakeDamage(float amount)
    {     
        health -= amount;
        healthDisplay.text = health.ToString();

        pulse.Play("Pulse", -1, 0);
        anim.SetFloat("health", health);

        if (health <= 0)
        {
            Death();
        }
    }

    //Death
    public void Death()
    {
        Instantiate(death, transform.position, transform.rotation);
        Destroy(this.gameObject);

        gm.NextLife();
        healthDisplay.text = 3.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heart"))
        {
            TakeDamage(-1f);
        }
        if (collision.CompareTag("Hazard"))
        {
            anim.Play("Flinch");
            TakeDamage(1f);
        }
        if (collision.CompareTag("End"))
        {
            TakeDamage(10000000000f);
        }
        if (collision.CompareTag("Goal"))
        {
            gm.CompleteLevel();
            Destroy(this.gameObject);
        }
    }
}
