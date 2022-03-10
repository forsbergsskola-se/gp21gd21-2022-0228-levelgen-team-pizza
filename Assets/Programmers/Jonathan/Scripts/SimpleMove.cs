using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField] float speed = 15.0f;
    [SerializeField] float rotationSpeed = 30.0f;

    [SerializeField] private Rigidbody rb;





    void FixedUpdate()
    {
        //float mH = Input.GetAxis("Horizontal");
        //float mV = Input.GetAxis("Vertical");

        //transform.forward(speed * Time.deltaTime * Input.GetAxis("Vertical"));

        //Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationSpeed * Time.fixedDeltaTime * mH);
       // rb.MoveRotation(rb.rotation * deltaRotation);

       //transform.Rotate(0f, rotationSpeed * Time.deltaTime * mH, 0f);
       Accelerate();
       rb.velocity = rb.velocity.normalized * speed;
       Rotate();


    }

    public void Rotate()
    {
        var _deltaRotation = Quaternion.Euler( Input.GetAxis("Horizontal")* Time.fixedDeltaTime * new Vector3(0f,rotationSpeed, 0f));
        rb.MoveRotation(rb.rotation * _deltaRotation);
    }

    public void Accelerate()
    {
        rb.AddForce(Input.GetAxis("Vertical") * speed * transform.forward, ForceMode.VelocityChange);
    }
}
