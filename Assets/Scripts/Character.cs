using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject clock;

    [HideInInspector]
    public bool foundClock;
    private Timer timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerKiller"))
        {
            Die();
        }
    }
    private void Start()
    {
        foundClock = false;
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    public void Die()
    {
        timer.time = 0;

        if (foundClock)
        {
            GameObject obj = Instantiate(clock);
            obj.transform.position = transform.position;
        }

    }
}
