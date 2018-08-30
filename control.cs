using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour 
{

    public float Speed = 5f;
    private CharacterController _controller;
    public Animator anim;
    private float inputH;
    private float inputV;
    public Rigidbody rbody;
    public float turnSmoothing = 15f;
    public float maxSpeed;
    public GameObject referencia; 

    void Start()
    {
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        rbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        if(rbody.velocity.magnitude > maxSpeed) {
            rbody.velocity = rbody.velocity.normalized * maxSpeed;
        }

        rbody.AddForce(inputV * referencia.transform.forward * Speed);
        rbody.AddForce(inputH * referencia.transform.right * Speed);

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        //float moveX = inputH * 20f * Time.deltaTime;
        //float moveZ = inputV * 50f * Time.deltaTime;
        //rbody.velocity = new Vector3(moveX, 0f, moveZ);
    }



}
