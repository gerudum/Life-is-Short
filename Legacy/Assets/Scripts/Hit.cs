using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Collider2D player;
    public Collider2D box;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object") && box.IsTouching(player))
        {
            collision.SendMessage("Death", null, SendMessageOptions.DontRequireReceiver);
        }
    }
}
