using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    public float range = 20.0f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    public void Ring()
    {
        Mob.TriggerSound(range, transform);
        audioSource.Play();

        transform.position = new Vector3(-100000000, 1000000, 0);

        Destroy(gameObject, 4);
    }
}
