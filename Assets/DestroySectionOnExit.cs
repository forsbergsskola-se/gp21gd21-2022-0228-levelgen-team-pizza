using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySectionOnExit : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(transform.parent.parent.gameObject);
        }
    }
}
