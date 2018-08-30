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

    void Start()
    {
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;
        rbody.velocity = new Vector3(moveX, 0f, moveZ);
    }

    void FixedUpdate()
    {
        float lh = Input.GetAxisRaw("Horizontal");
        float lv = Input.GetAxisRaw("Vertical");

    }

    void Rotating(float lh, float lv)
    {
        Vector3 targetDirection = new Vector3(lh, 0f, lv);

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);
       
        GetComponent<Rigidbody>().MoveRotation(newRotation);
    }


}
