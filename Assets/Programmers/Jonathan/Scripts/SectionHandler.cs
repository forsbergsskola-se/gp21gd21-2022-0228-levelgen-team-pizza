using System;
using UnityEngine;

/// <summary>
///     Atm, just contains its own coordinates
/// </summary>
public class SectionHandler : MonoBehaviour
{
    private DungeonGenerator dungeonGenerator => FindObjectOfType<DungeonGenerator>();
    private Transform player => GameObject.FindGameObjectWithTag("Player").transform;
    [HideInInspector]public Vector2 sectionCoords;

    [SerializeField]
    private float roomDestroyDistance = 250f; // Distance from pivot until rooms are destroyed

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > roomDestroyDistance)
        {
           Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log($"Room Destroyed at coords {sectionCoords}");
        dungeonGenerator.occupiedSpots.Remove(sectionCoords);

    }
}
