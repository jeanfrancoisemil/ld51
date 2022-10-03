using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class Mob : MonoBehaviour
{
    public float acceleration = 2;

    private Rigidbody2D m_Rigidbody;
    private BoxCollider2D m_Collider;

    private Vector3 targetPosition;

    private Transform gfx;
    private Animator anim;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<BoxCollider2D>();
        gfx = transform.Find("GFX");
        anim = gfx.GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        if (targetPosition == Vector3.zero)
        {
            anim.Play("Idlin");
            gfx.localPosition = new Vector3(gfx.localPosition.x, 0f, gfx.localPosition.z);
            gfx.rotation = Quaternion.Euler(0f, 0f, 0f);
            return;
        }

        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;
        direction.z = 0;
        direction.Normalize();
        Move(direction);
        gfx.GetComponent<SpriteRenderer>().flipX = m_Rigidbody.velocity.x > 0;
        if (Vector3.Distance(targetPosition, transform.position) < 0.2)
        {
            targetPosition = Vector3.zero;
            gfx.localPosition = new Vector3(gfx.localPosition.x, 0f, gfx.localPosition.z);
            gfx.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.Play("Standin");
        }else
        {
            gfx.localPosition = new Vector3(gfx.localPosition.x, -0.36f, gfx.localPosition.z);
            anim.Play("Rollin");
            gfx.Rotate(0f, 0f, 7f * -Mathf.Sign(m_Rigidbody.velocity.x));
        }
    }

    void Move(Vector3 direction)
    {
        m_Rigidbody.velocity = direction * acceleration;
    }

    public void OnSound(Vector3 position)
    {
        targetPosition = position;
    }

    public void OnSoundEnded()
    {
        targetPosition = Vector3.zero;
    }

    public static void TriggerSound(float range, Transform source)
    {
        Mob[] mobs = FindObjectsOfType<Mob>();
        foreach (Mob mob in mobs)
        {
            if (Vector3.Distance(mob.transform.position, source.position) <= range)
            {
                mob.StartCoroutine(mob.StartMovement(mob, source.position));
                //mob.OnSound(source);
                //start coroutine => 0.5s => OnSound + ballin
            }
        }
    }

    public IEnumerator StartMovement(Mob mob, Vector3 source)
    {
        anim.Play("Exclamatin");
        yield return new WaitForSeconds(0.5f);
        mob.OnSound(source);
        anim.Play("Ballin");
    }
}
