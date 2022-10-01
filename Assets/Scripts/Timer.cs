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
    public float time = 10;
    private float seconds;
    public TextMeshProUGUI timeText;

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
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            DisplayTime(time);
        }
        else
        {
            AlarmClock[] clocks = FindObjectsOfType<AlarmClock>();
            foreach (AlarmClock clock in clocks)
                Destroy(clock.gameObject);
            Player.GetComponent<Character>().Die();

            Player.transform.position = lastCheckPoint;
            time = 10;
        }

        seconds = Mathf.FloorToInt(time % 60);

    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
