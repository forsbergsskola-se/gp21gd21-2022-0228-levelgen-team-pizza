using System.Collections.Generic;
using UnityEngine;

//Handles spawning of rooms when player enter room spawning trigger
public class SpawnRoom : MonoBehaviour
{
    [SerializeField]
    private List<sectionDirection> roomDirections = new List<sectionDirection>();

    private DungeonGenerator m_DungeonGenerator;
    private bool hasBeenTriggered;

    private void Start()
    {
        m_DungeonGenerator = FindObjectOfType<DungeonGenerator>(); //Lazy implementation but think it will do for this occasion. Or maybe change later
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player enter zone close to a non-existing room --> spawn room
        if (other.CompareTag("Player")  ) //&& !hasBeenTriggered
        {
            var parent = transform.parent.parent.GetComponent<SectionHandler>(); // get room handler for coords

            foreach (var roomDirection in roomDirections) // foreach room dir to spawn
            {
                m_DungeonGenerator.GenerateSection(roomDirection, parent.sectionCoords); // spawn room
            }
        }

        // // dont allow the spawner to trigger more than once. Optimization, since it would not anyways since checking position before spawn,
        // // but now we save a search in list of coords.
        hasBeenTriggered = true;
    }
}
