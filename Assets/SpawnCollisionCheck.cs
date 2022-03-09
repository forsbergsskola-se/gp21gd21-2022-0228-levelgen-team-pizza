using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Triggercol");
        // if (other.CompareTag("Object"))
        // {
        //     Debug.Log("Inside");
        //     Destroy(transform.parent.gameObject);
        //     Debug.Log("Destroyed");
        // }
    }
}
