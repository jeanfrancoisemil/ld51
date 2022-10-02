using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 to;
    public float speed = 0.005f;

    public Button[] buttons;
    public bool needAllButtons = true;

    private Vector2 fromTarget;
    private Vector2 target;

    void Start()
    {
        Vector2 from = transform.position;
        target = from + to;
        fromTarget = transform.position;
    }

    void Update()
    {
        if (!IsDoorOpen())
        {
            return;
        }

        transform.position = Vector2.Lerp(transform.position, target, speed);
        if (Vector2.Distance(transform.position, target) < 0.1)
        {
            Vector2 temp = target;
            target = fromTarget;
            fromTarget = temp;
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
                }
                else
                {
                    button_count++;
                }
            }
            return button_count == buttons.Length;
        }
    }
}
