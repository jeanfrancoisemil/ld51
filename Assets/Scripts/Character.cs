using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject clock;

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
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    public void Die()
    {
        timer.time = 0;
        GameObject obj = Instantiate(clock);
        obj.transform.position = transform.position;
    }
}
