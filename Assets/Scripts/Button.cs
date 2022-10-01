using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [HideInInspector]
    public bool isPressed = false;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isPressed = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isPressed = false;
    }
}
