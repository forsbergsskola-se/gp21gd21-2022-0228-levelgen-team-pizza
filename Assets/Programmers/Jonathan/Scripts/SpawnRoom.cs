using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField]
    private DungeonGeneratorJJ dungeonGeneratorJj;
    [SerializeField] private RoomDirection RoomDirection1;
     [SerializeField] private RoomDirection RoomDirection2;
     private bool hasBeenTriggered = false;
     private void Start()
     {
         dungeonGeneratorJj = FindObjectOfType<DungeonGeneratorJJ>();
         Debug.Log(dungeonGeneratorJj);
     }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenTriggered)
        {
            var root = transform.root.GetComponent<RoomHandler>();
            dungeonGeneratorJj.GenerateRoom(RoomDirection1,root.roomCoords);
            dungeonGeneratorJj.GenerateRoom(RoomDirection2, root.roomCoords);
        }

        hasBeenTriggered = true;
    }
}
