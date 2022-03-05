using UnityEngine;

//Handles spawning of rooms when player enter room spawning trigger
public class SpawnRoom : MonoBehaviour
{
    [SerializeField]
    private RoomDirection RoomDirection1;

    [SerializeField]
    private RoomDirection RoomDirection2;

    private DungeonGeneratorJJ dungeonGeneratorJj;
    private bool hasBeenTriggered;

    private void Start()
    {
        dungeonGeneratorJj = FindObjectOfType<DungeonGeneratorJJ>(); // better way here maybe. Lazy now
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player enter zone close to a non-existing room --> spawn room
        if (other.CompareTag("Player") && !hasBeenTriggered)
        {
            var root = transform.root.GetComponent<RoomHandler>(); // get room handler for coords
            dungeonGeneratorJj.GenerateRoom(RoomDirection1, root.roomCoords); // spawn in first direction
            dungeonGeneratorJj.GenerateRoom(RoomDirection2, root.roomCoords); //spawn in second direction
        }

        // dont allow the spawner to trigger more than once. Optimization, since it would not anyways since checking position before spawn,
        // but now we save a search in list of coords.
        hasBeenTriggered = true;
    }
}
