using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerAA : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnZones;

    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private int maxSpawn;

    public bool coroutineRunning;

    private void Update()
    {
        SpawnEnemies();
        if (!coroutineRunning)
        {
            StartCoroutine(EnemyChange());
        }
    }


    private void SpawnEnemies()
    {

        var spawnNum = Random.Range(0, spawnZones.Length - 1);
        var enemyNum = Random.Range(0, enemyPrefabs.Length - 1);


        while(enemyList.Count < maxSpawn)
        {
            enemyList.Add(Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity));
        }


    }

    private IEnumerator EnemyChange()
    {

        yield return new WaitForSeconds(3); // 3 second delay
        enemyList.RemoveAt(0);
        Destroy(enemyList[0]);
        coroutineRunning = false;

    }
}
