using UnityEngine;

/// <summary>
///     Atm, just contains its own coordinates
/// </summary>
public class SectionHandler : MonoBehaviour
{
    [HideInInspector]
    public Vector2 SectionCoords;

    public bool hasANavmesh;

    [SerializeField]
    private float roomDestroyDistance = 250f; // Distance from pivot until rooms are destroyed

    private DungeonGenerator dungeonGenerator => FindObjectOfType<DungeonGenerator>();
    private Transform player => GameObject.FindGameObjectWithTag("Player").transform;

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > roomDestroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        dungeonGenerator.occupiedSpots.Remove(SectionCoords);
    }
}
