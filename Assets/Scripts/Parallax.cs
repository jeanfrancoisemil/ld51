using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float mouvementRelatif;

    private Timer timer;

    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }
    void Update()
    {
        
        transform.position = new Vector2 (cam.position.x * mouvementRelatif - timer.offsetX, cam.position.y * mouvementRelatif - timer.offsetY);
    }
}
