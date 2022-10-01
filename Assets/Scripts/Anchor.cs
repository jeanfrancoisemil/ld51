using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public static List<Anchor> AnchorList = new List<Anchor>();

    public int cameraSize = 5;

    void Start()
    {
        AnchorList.Add(this);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 top0 = transform.position + new Vector3(-(cameraSize) * (16 / 9) * 1.7f, cameraSize / (16/9), 0);
        Vector3 top1 = transform.position + new Vector3((cameraSize) * (16 / 9) * 1.7f, cameraSize / (16 / 9), 0);

        Vector3 bottom0 = transform.position + new Vector3(-(cameraSize) * (16 / 9) * 1.7f, -cameraSize / (16 / 9), 0);
        Vector3 bottom1 = transform.position + new Vector3((cameraSize) * (16 / 9) * 1.7f, -cameraSize / (16 / 9), 0);

        Gizmos.DrawLine(top0, top1);
        Gizmos.DrawLine(bottom0, bottom1);
        Gizmos.DrawLine(top0, bottom0);
        Gizmos.DrawLine(top1, bottom1);
    }
}
