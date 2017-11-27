using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

    GameObject Manager;
    // Use this for initialization
    void Start()
    {
        Manager = GameObject.FindWithTag("UIManager");
    }

    void ResumeGame()
    {
        Manager.GetComponent<Pause>().TogglePausing();

    }
}
