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
}
