using UnityEngine;

public class WeightedGameObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private WeightedGOTable weightedGoTable;

    [SerializeField]
    private float radius;

    [SerializeField]
    private int numberOfGameObjects;

    [SerializeField]
    private int maxSpawnAttemptsPerObstacle = 10;
    [SerializeField]
    private float obstacleCheckRadius = 1f;

    private void Awake()
    {
        for (var i = 0; i < numberOfGameObjects; i++)
        {

            Vector3 position = Vector3.zero;

            bool validPosition = false;

            int spawnAttempts = 0;

            // While we don't have a valid position
            //  and we haven't tried spawning this obstable too many times
            while(!validPosition && spawnAttempts < maxSpawnAttemptsPerObstacle)
            {
                // Increase our spawn attempts
                spawnAttempts++;

                // Pick a random position
                var randomSpawnPos = transform.position + Random.insideUnitSphere*radius;
                position = new Vector3(randomSpawnPos.x, transform.position.y, randomSpawnPos.z);

                // This position is valid until proven invalid
                validPosition = true;

                // Collect all colliders within our Obstacle Check Radius
                Collider[] colliders = Physics.OverlapSphere(position, obstacleCheckRadius);

                // Go through each collider collected
                foreach(Collider col in colliders)
                {
                    // If this collider is tagged "Obstacle"
                    if(col.tag == "Object" || col.tag =="Wall")
                    {
                        // Then this position is not a valid spawn position
                        validPosition = false;
                    }
                }
            }


            if (validPosition)
            {
                SpawnGameObject(position);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void SpawnGameObject(Vector3 position)
    {
        // var randomSpawnPos = transform.position + Random.insideUnitSphere*radius;
        // var corrPos = new Vector3(randomSpawnPos.x, transform.position.y, randomSpawnPos.z);

        var go = Instantiate(weightedGoTable.PickGO(), position, Quaternion.identity);
        go.transform.parent = transform;
    }
}
