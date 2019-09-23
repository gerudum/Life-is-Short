using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
