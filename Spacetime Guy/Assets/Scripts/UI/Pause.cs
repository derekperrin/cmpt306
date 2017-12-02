using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
   // public Text timer_text;
    public GameObject pause_menu;

    public bool is_paused = false;
    // Use this for initialization
    void Start()
    {
        //ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        //timer_text.text = "Time: " + (int)Time.time;

        if (Input.GetButtonDown("Pause"))
        {
            TogglePausing();
        }

    }
    public void TogglePausing()
    {
        is_paused = !is_paused;

        if (is_paused)
        {
            //pause the game
            PauseGame();
        }
        else
        {
            ResumeGame();
            //resume the game
        }
    }
    public void PauseGame()
    {
        pause_menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1;
    }
}