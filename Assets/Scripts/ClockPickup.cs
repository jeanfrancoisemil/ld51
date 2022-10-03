using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPickup : MonoBehaviour
{

    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController>() != null)
        {
            Player.GetComponent<Character>().foundClock = true;
            this.gameObject.SetActive(false);
        }
    }

}
