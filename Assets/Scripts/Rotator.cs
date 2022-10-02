using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public Boolean reverse;
    public float speed = 1;

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 45f;
    }

    void FixedUpdate()
    {
        if(reverse == true)
        {
            rigidBody2D.rotation -= 1.0f * speed;
        }else
        {
            rigidBody2D.rotation += 1.0f * speed;
        }
        
    }
}
