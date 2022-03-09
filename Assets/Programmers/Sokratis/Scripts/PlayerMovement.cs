using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _velocity;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocity.z = Input.GetAxis("Vertical");
        _velocity.x = Input.GetAxis("Horizontal");

        _navMeshAgent.velocity = _velocity * 50;
    }
}
