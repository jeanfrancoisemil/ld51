using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Mob : MonoBehaviour
{
    public float acceleration = 2;

    private Rigidbody2D m_Rigidbody;
    private BoxCollider2D m_Collider;

    private Transform target;
    private int targetPriority;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        direction.z = 0;
        direction.Normalize();

        Move(direction);
    }

    void Move(Vector3 direction)
    {
        m_Rigidbody.velocity = direction * acceleration;
    }

    public void OnSound(int priority, Transform source)
    {
        if (targetPriority > 0 && priority < targetPriority)
            return;
        target = source;
        targetPriority = priority;
    }

    public void OnSoundEnded()
    {
        targetPriority = 0;
        target = null;
    }

    public static void TriggerSound(int priority, Transform source)
    {
        Mob[] mobs = FindObjectsOfType<Mob>();
        foreach (Mob mob in mobs)
            mob.OnSound(priority, source);
    }
}
