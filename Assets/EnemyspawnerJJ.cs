using UnityEngine;

public class EnemyspawnerJJ : MonoBehaviour
{
    [SerializeField]
    private WeightedGOTable enemyTable;

    [SerializeField]
    private float radius;

    [SerializeField]
    private int numberOfEnemies;

    private void Start()
    {
        for (var i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void SpawnEnemy()
    {
        var randomSpawnPos = transform.position + Random.insideUnitSphere*radius;
        var corrPos = new Vector3(randomSpawnPos.x, transform.position.y, randomSpawnPos.z);
        var enemy = Instantiate(enemyTable.PickGO(), corrPos, Quaternion.identity);
        enemy.transform.parent = transform;
    }
}
