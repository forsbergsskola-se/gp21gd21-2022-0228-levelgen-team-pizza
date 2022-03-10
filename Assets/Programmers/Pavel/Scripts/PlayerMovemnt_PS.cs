using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt_PS : MonoBehaviour{

    [SerializeField] Rigidbody rb;
    [SerializeField] int speed;

    Vector3 inputVector;
    float mh = Input.GetAxisRaw("Horizontal");
    float mv = Input.GetAxisRaw("Vertical");

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        inputVector = new Vector3(mh * speed,rb.velocity.y,mv * speed);
        transform.LookAt(transform.position + new Vector3(inputVector.x,0,inputVector.z));
    }

    void FixedUpdate(){
        rb.velocity = inputVector;
    }
}

