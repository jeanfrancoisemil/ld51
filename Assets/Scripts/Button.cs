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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPressed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPressed = false;
    }
}
