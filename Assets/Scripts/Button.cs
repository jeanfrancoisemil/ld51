using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private AudioSource clickSound;
    [HideInInspector]
    public bool isPressed = false;

    void Start()
    {
        clickSound = GetComponent<AudioSource>();
        clickSound.Pause();
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPressed = true;
        clickSound.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPressed = false;
    }
}
