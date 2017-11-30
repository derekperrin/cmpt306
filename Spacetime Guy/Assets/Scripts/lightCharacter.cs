using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCharacter : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {

        transform.position = new Vector3(0,0,-1);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
	}
}
