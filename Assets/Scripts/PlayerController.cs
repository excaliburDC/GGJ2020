﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float groundDist = 0.2f;
   // public float dashDist = 5f;

    public LayerMask ground;
    public Rigidbody playerRb;
    public Vector3 input;
    public bool isGrounded = true;
    public Transform groundCheck;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
        groundCheck = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, ground, QueryTriggerInteraction.Ignore);
        
        input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");

        if (input != Vector3.zero)
        {
            transform.forward = input;

            //walk sound and animation
        }
            

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * gravity), ForceMode.VelocityChange);

            //play jump sound
        }
            

        //if (Input.GetKeyDown(KeyCode.R)) //dash movement
        //{
        //    Vector3 dashVel = Vector3.Scale(transform.forward, dashDist * new Vector3(Mathf.Log(1f / (Time.deltaTime * playerRb.drag + 1)) /
        //            -Time.deltaTime, 0f, (Mathf.Log(1f / (Time.deltaTime * playerRb.drag + 1)) / -Time.deltaTime)));

        //    playerRb.AddForce(dashVel, ForceMode.VelocityChange);
        //}
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + input * speed * Time.fixedDeltaTime);
    }
}