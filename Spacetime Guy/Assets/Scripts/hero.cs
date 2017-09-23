using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour {

    private Rigidbody2D heroRigidBody;
    [SerializeField]
    private float speed;
    // Use this for initialization

    void Start ()
    {
        heroRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalArrows = Input.GetAxis("Horizontal");  //A(negative) D(positive) arrow keys 
        float verticalArrows = Input.GetAxis("Vertical");  //S(negative) W(positive) arrow keys 
        Movement(horizontalArrows, verticalArrows);
    }

    private void Movement(float horizontal, float vertical)
    {
        Vector2 movement = new Vector2(horizontal, vertical);
        heroRigidBody.AddForce(movement * speed);
        if (heroRigidBody.velocity.magnitude > 8)
        {
            speed = 1;
        }
        /*
        heroRigidBody.velocity = new Vector2(horizontal * speed, heroRigidBody.velocity.y);
        heroRigidBody.velocity = new Vector2(vertical * speed, heroRigidBody.velocity.x); */
        //myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }
    }
