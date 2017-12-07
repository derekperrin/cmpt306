using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    public Text Score;
    // Use this for initialization
    void Start()
    {
        Score.text = "Levels Completed:" + GlobalControl.Instance.levelsCompleted;
    }
}
