using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    private Transform player;
    private float distanceToPlayer;
    private bool noObstacle;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<SimpleMove>().transform;
    }

    private void Update()
    {
        distanceToPlayer =  Vector3.Distance(transform.position, player.position);

        Vector3 direction = player.position - this.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            noObstacle = hit.transform.CompareTag("Player");
        }

    }

    private void OnMouseDown()
    {
        if (distanceToPlayer <= range && noObstacle)
        {

        }
        Destroy(gameObject);
    }
}
