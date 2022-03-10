using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");

        rb.velocity = (transform.forward * mv) * speed * Time.deltaTime;
        transform.Rotate((transform.up * mh) * rotationSpeed * Time.deltaTime);
    }
}
