using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private static Timer instance;
    public Vector2 lastCheckPoint;
    public GameObject Player;
    public GameObject Clock;
    public float time = 10;
    private float seconds;
    public TextMeshProUGUI timeText;
    private Boolean timeStart;
    private Rigidbody2D rb;
    public Transform cam;
    public float offsetX;
    public float offsetY;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Player.transform.position = lastCheckPoint;
        Clock.transform.position = new Vector2(0,0);
        rb = Player.GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (rb.velocity.x == 0 && time == 10)
        {
            timeStart = false;
            offsetX = cam.transform.position.x;
            offsetY = cam.transform.position.y;

        }
        else
        {
            timeStart = true;
        }

        DisplayTime(time);

        if (time > 0)
        {
            if (timeStart == true)
            {
                time -= Time.deltaTime;
            }
        }
        else if (time <= 2.5)
        {
            if (Player.GetComponent<Character>().foundClock)
            {
                AlarmClock clock = FindObjectOfType<AlarmClock>();
                if (clock != null)
                {
                    clock.Ring();
                }
            }
        }
        else if (time <= 0)
        {
            Player.GetComponent<Character>().Die();

            Player.transform.position = lastCheckPoint;
            time = 10;
            timeStart = false;
            Clock.transform.position = new Vector2(0,0);
        }

        seconds = Mathf.FloorToInt(time % 60);

    }

    void DisplayTime(float timeToDisplay)
    {        
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}", seconds);
    }
}
