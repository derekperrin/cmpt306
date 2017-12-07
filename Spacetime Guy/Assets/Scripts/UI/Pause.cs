using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject Children;

    public Text timer_text;
    public float timescale;

    // public bool is_paused = false;
    // Use this for initialization
    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        //timer_text.text = "Time: " + (int)Time.time;
        timescale = Time.timeScale;
        if (Input.GetButtonDown("Pause"))
        {
            TogglePausing();
        }

    }

    public void TogglePausing()
    {
        // is_paused = !is_paused;

        if (Time.timeScale == 1)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    public void PauseGame()
    {
        Children.SetActive(true);
        Time.timeScale = 0;
        Debug.Log(Time.timeScale.ToString());
    }
    public void ResumeGame()
    {
        Children.SetActive(false);
        Time.timeScale = 1;
    }



}