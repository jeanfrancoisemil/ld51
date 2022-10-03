using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    public float range = 20.0f;
    private AudioSource audioSource;

    private bool hasRing = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    public void Ring()
    {
        if (hasRing)
            return;

        Mob.TriggerSound(range, transform);
        audioSource.Play();

        transform.position = new Vector3(-100000000, 1000000, 0);

        Destroy(gameObject, 4);
        hasRing = true;
    }
}
