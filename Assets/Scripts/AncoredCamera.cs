using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AncoredCamera : MonoBehaviour
{
    // Options
    [Range(0.0001f, 1f)]
    public float smoothness = 0.01f;
    public Transform player;

    private Anchor currentAnchor = null;

    void Start()
    {
    }

    void Update()
    {
        // Calculer la distance de toute les ancres pour trouver la plus proche
        float minDistance = 9999;
        Anchor nearestAnchor = null;

        //Debug.LogFormat("{0}", Anchor.AnchorList.Count);

        foreach (Anchor anchor in Anchor.AnchorList)
        {
            float distance = DistanceXY(anchor.transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestAnchor = anchor;
            }
        }

        currentAnchor = nearestAnchor;

        // Deplacer la camera vers l'ancre
        if (currentAnchor == null)
        {
            return;
        }

        Vector3 origin = transform.position;
        Vector3 target = currentAnchor.transform.position;

        Vector3 newPosition = Vector3.Lerp(origin, target, smoothness);
        newPosition.z = -10;
        transform.position = newPosition;

        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, currentAnchor.cameraSize, smoothness);
    }

    private static float DistanceXY(Vector3 a, Vector3 b) {
        return (b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y);
    }
}
