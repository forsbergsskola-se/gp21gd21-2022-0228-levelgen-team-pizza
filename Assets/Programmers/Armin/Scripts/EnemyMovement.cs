using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public LayerMask PlayerLayer;
    [SerializeField]
    private float moveSpeed = 10f;
    private Transform playerPosition;
    private Rigidbody rb;
    private Vector3 movement;
    [SerializeField] private float sphereRadius = 5f;
    private bool noObstacle;
    private Vector3 lastPlayerSeen;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPosition = GameObject.FindObjectOfType<SimpleMove>().transform;
    }

    void Update()
    {
        Vector3 direction = playerPosition.position - this.transform.position;


        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            noObstacle = hit.transform.CompareTag("Player");
            lastPlayerSeen = hit.transform.position;
            Debug.Log("We are hitting " + hit.point);
        }

        if (noObstacle)
        {
            direction = playerPosition.position - transform.position;
        }
        else
        {
            direction = lastPlayerSeen - transform.position;
        }

        if ((Physics.CheckSphere(transform.position, sphereRadius, PlayerLayer)))
        {
            direction.Normalize();
            movement = direction;

            MoveCharacter(movement);
        }

    }

    void MoveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
