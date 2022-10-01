using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AncoredCamera : MonoBehaviour
{
    // Options
    [Range(0.0001f, 1f)]
    public float smoothness = 0.01f;

    private Anchor currentAnchor = null;

    void Start()
    {
    }

    void Update()
    {
        // Calculer la distance de toute les ancres pour trouver la plus proche
        float minDistance = 999;
        Anchor nearestAnchor = null;

        //Debug.LogFormat("{0}", Anchor.AnchorList.Count);

        foreach (Anchor anchor in Anchor.AnchorList)
        {
            float distance = Vector3.Distance(anchor.transform.position, this.transform.position);
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
    }
}
