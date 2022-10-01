using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Button[] buttons;
    public bool stayOpen = false;
    public bool needAllButtons = true;

    [HideInInspector]
    public bool isOpen = false;

    void Start()
    {
    }

    void Update()
    {
        if (buttons == null || (stayOpen && isOpen))
        {
            return;
        }

        var collider = GetComponent<BoxCollider2D>();

        if (IsDoorOpen())
        {
            collider.enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            isOpen = true;
        }
        else
        {
            collider.enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            isOpen = false;
        }
    }

    private bool IsDoorOpen()
    {
        if (needAllButtons)
        {
            foreach (Button button in buttons)
            {
                if (button.isPressed)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            var button_count = 0;

            foreach (Button button in buttons)
            {
                if (!button.isPressed)
                {
                    return false;
                } else
                {
                    button_count++;
                }
            }
            return button_count == buttons.Length;
        }
    }
}
