using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

        public Text healthText;
        private Player target;

    // Use this for initialization
    private void Awake()
    {}
    void Start()
        //start it with some bullshit value you probably won't ever do this maybe you just hide it until UpdateUI is called.
        { healthText.text = "Health: 100/100"; }

        // Update is called once per frame
        void Update()
        {
          //  float countedValue = target.healthCurrent;
           // healthText.text = "Health:" + countedValue + " / " + target.healthMax;
        }

    void UpdateUI()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        healthText.text = "Health: " + target.healthCurrent + " / " + target.healthMax;
    }
    }

