using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    public float range = 20.0f;

    void Start()
    {
    }

    void Update()
    {
    }

    public void Ring()
    {
        Mob.TriggerSound(range, transform);
    }
}
