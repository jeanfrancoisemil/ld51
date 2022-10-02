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

    private Vector3 targetPosition;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (targetPosition == Vector3.zero)
        {
            return;
        }

        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;
        direction.z = 0;
        direction.Normalize();

        Move(direction);
        if (Vector3.Distance(targetPosition, transform.position) < 0.1)
        {
            targetPosition = Vector3.zero;
        }
    }

    void Move(Vector3 direction)
    {
        m_Rigidbody.velocity = direction * acceleration;
    }

    public void OnSound(int priority, Transform source)
    {
        targetPosition = source.position;
    }

    public void OnSoundEnded()
    {
        targetPosition = Vector3.zero;
    }

    public static void TriggerSound(int priority, Transform source)
    {
        Mob[] mobs = FindObjectsOfType<Mob>();
        foreach (Mob mob in mobs)
            mob.OnSound(priority, source);
    }
}
