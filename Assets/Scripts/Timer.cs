using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private static Timer instance;
    public Vector2 lastCheckPoint;
    public GameObject Player;
    public float time = 11;
    private float seconds;
    public TextMeshProUGUI timeText;
    public Rigidbody2D rb;

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
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (time > 0)
        {
            if (rb.velocity.x == 0 && time > 10.99)
            {
                time = 11;
            }
            else
            {
                time -= Time.deltaTime;
                DisplayTime(time);
            }
        }
        else if (time <= 0)
        {
            AlarmClock[] clocks = FindObjectsOfType<AlarmClock>();
            foreach (AlarmClock clock in clocks)
                Destroy(clock.gameObject);
            Player.GetComponent<Character>().Die();

            Player.transform.position = lastCheckPoint;
            time = 11;
        }

        seconds = Mathf.FloorToInt(time % 60);

    }

    void DisplayTime(float timeToDisplay)
    {
        
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}", seconds);
    }
}
