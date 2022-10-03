using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        sound.Play();
    }

    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
}
