using UnityEngine;

public class WeightedGameObjectSpawnerJJ : MonoBehaviour
{
    [SerializeField]
    private WeightedGOTable weightedGoTable;

    [SerializeField]
    private float radius;

    [SerializeField]
    private int numberOfGameObjects;

    private void Start()
    {
        for (var i = 0; i < numberOfGameObjects; i++)
        {
            SpawnGameObject();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void SpawnGameObject()
    {
        var randomSpawnPos = transform.position + Random.insideUnitSphere*radius;
        var corrPos = new Vector3(randomSpawnPos.x, transform.position.y, randomSpawnPos.z);
        var go = Instantiate(weightedGoTable.PickGO(), corrPos, Quaternion.identity);
        go.transform.parent = transform;
    }
}
