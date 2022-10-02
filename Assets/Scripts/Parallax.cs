using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float mouvementRelatif;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (cam.position.x * mouvementRelatif, cam.position.y * mouvementRelatif);
    }
}
