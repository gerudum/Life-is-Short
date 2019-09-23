using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public Vector3 offset = new Vector3(5, 0, -10);
    public void FixedUpdate()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }  
    }
}
