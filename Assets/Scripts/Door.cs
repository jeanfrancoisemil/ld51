using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Button[] buttons;
    public bool stayOpen = false;
    public bool needAllButtons = true;
    public bool defaultOpen = false;
    public bool resetButtonsAfterTime = false;
    public float resetTime = 0;

    [HideInInspector]
    public bool isOpen = false;
    private float timer = 0;
    private bool timerStarted = false;

    private BoxCollider2D box;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (buttons == null)
        {
            return;
        }

        if (timerStarted && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timerStarted)
        {
            // Fin du timer
            foreach (var button in buttons)
                button.isPressed = false;
            timerStarted = false;

            CloseDoor();
        }

        if (isOpen && stayOpen)
        {
            return;
        }

        if (IsDoorOpen())
        {
            OpenDoor();

            // Demarrer le timer
            if (resetButtonsAfterTime && !timerStarted)
            {
                timer = resetTime;
                timerStarted = true;
            }
        }
        else
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        box.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        isOpen = true;
    }

    private void CloseDoor()
    {
        box.enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        isOpen = false;
    }

    private bool IsDoorOpen()
    {
        if (needAllButtons)
        {
            foreach (Button button in buttons)
            {
                if (button.isPressed)
                {
                    return !defaultOpen;
                }
            }
            return defaultOpen;
        }
        else
        {
            var button_count = 0;

            foreach (Button button in buttons)
            {
                if (!button.isPressed)
                {
                    return defaultOpen;
                } else
                {
                    button_count++;
                }
            }
            //return button_count == buttons.Length;
            if (!defaultOpen)
                return button_count == buttons.Length;
            return button_count != buttons.Length;
        }
    }
}
