using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    private Transform m_Player;
    private float m_DistanceToPlayer;
    private bool m_NoObstacle;

    private void Awake()
    {
        m_Player = GameObject.FindObjectOfType<SimpleMove>().transform;
    }

    private void Update()
    {
        m_DistanceToPlayer =  Vector3.Distance(transform.position, m_Player.position);

        Vector3 direction = m_Player.position - this.transform.position;
        if (Physics.Raycast(transform.position, direction, out var hit))
        {
            m_NoObstacle = hit.transform.CompareTag("Player");
        }

    }

    private void OnMouseDown()
    {
        Debug.Log("We are hitting " + Input.GetMouseButtonDown(0));
        if (m_DistanceToPlayer <= range)
        {
            Destroy(gameObject);
        }

    }
}
