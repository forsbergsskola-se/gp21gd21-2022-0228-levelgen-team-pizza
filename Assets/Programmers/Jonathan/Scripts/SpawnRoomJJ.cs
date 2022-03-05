using System.Collections.Generic;
using UnityEngine;

//Handles spawning of rooms when player enter room spawning trigger
public class SpawnRoomJJ : MonoBehaviour
{
    [SerializeField]
    private List<RoomDirection> roomDirections = new List<RoomDirection>();

    private DungeonGeneratorJJ dungeonGeneratorJj;
    private bool hasBeenTriggered;

    private void Start()
    {
        dungeonGeneratorJj = FindObjectOfType<DungeonGeneratorJJ>(); //Lazy implementation but think it will do for this occasion. Or maybe change later
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player enter zone close to a non-existing room --> spawn room
        if (other.CompareTag("Player") && !hasBeenTriggered)
        {
            var root = transform.root.GetComponent<RoomHandlerJJ>(); // get room handler for coords

            foreach (var roomDirection in roomDirections) // foreach room dir to spawn
            {
                dungeonGeneratorJj.GenerateRoom(roomDirection, root.roomCoords); // spawn room
            }
        }

        // dont allow the spawner to trigger more than once. Optimization, since it would not anyways since checking position before spawn,
        // but now we save a search in list of coords.
        hasBeenTriggered = true;
    }
}
