using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Health is the amount of seconds your life will last.
    public float health = 3f;
    //How many seconds of movement per health lost.
    public float healthTimer = 1f;

    //Death Effect
    public GameObject death;
    
    //Ghost Effect
    public GameObject ghostEffect;

    //Cache
    private GameManager gm;
    private Animator anim;
    private Rigidbody2D rb;
    
    private Animator pulse;
    private Text healthDisplay;
    private SpriteRenderer sr;
    public void Start()
    {
        //Gameplay
        anim = GetComponent<Animator>();
        gm = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
        
        //Interface
        healthDisplay = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        pulse = GameObject.FindGameObjectWithTag("Pulse").GetComponent<Animator>();

        //Random Player Color
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
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

    //Leave behind an afterimage when getting hurt.
    public void Ghost(){
        GameObject ghosting = Instantiate(ghostEffect,transform.position,transform.rotation);
        SpriteRenderer ghoster = ghosting.GetComponent<SpriteRenderer>();

        Color color = GetComponent<SpriteRenderer>().color;
        ghoster.color = new Color(color.r, color.g, color.b,0.4f);
    }
    
    //Taking damage, die if health hits 0
    public void TakeDamage(float amount)
    {     
        //After image
        Ghost();

        health -= amount;
             
        //Heart pulse effect and health display
        healthDisplay.text = health.ToString();
        anim.SetFloat("health", health);
        pulse.Play("Pulse", -1, 0);        
        
        //Your HP hits zero, you die!!!
        if (health <= 0)
        {
            Death();
        }
    }

    //Death
    public void Death()
    {
        //Death Effect
        Instantiate(death, transform.position, transform.rotation);
        Destroy(this.gameObject);

        //Move on the to next life while dying
        gm.NextLife();
        //Reset health
        healthDisplay.text = 3.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Hearts restore health
        if (collision.CompareTag("Heart"))
        {
            TakeDamage(-1f);
        }
        
        //Hazards make you take more damage
        if (collision.CompareTag("Hazard"))
        {
            anim.Play("Flinch");
            TakeDamage(1f);
        }
        
        //Some hazards are a insta-kill
        if (collision.CompareTag("End"))
        {
            TakeDamage(10000000000f);
        }

        //Key
        if (collision.CompareTag("Key"))
        {
            gm.keys += 1;
            Destroy(collision.gameObject);  
        }

        //Reaching the goal completes the level
        if (collision.CompareTag("Goal"))
        {
            if(gm.keys >= gm.requiredKeys)
            {
                gm.CompleteLevel();
                Destroy(this.gameObject);
            }
        }
    }
}
