using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerAA : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnZones;

    [SerializeField]
    private GameObject[] enemies;
    private int spawnNum;
    private int enemyNum;
    private GameObject enemy;
    private Transform enemySpawn;

    private void Awake()
    {
        enemies[0].SetActive(false);
        enemies[1].SetActive(false);
        enemies[2].SetActive(false);
    }

    private void Start()
    {
        spawnNum = Random.Range(0, spawnZones.Length);
        enemyNum = Random.Range(0, enemies.Length);

        enemy = enemies[enemyNum];
        enemySpawn = spawnZones[spawnNum];

        enemy.transform.position = enemySpawn.transform.position;
        enemy.SetActive(true);

    }

    private void Update()
    {
        StartCoroutine(EnemyChange());
    }

    IEnumerator EnemyChange()
    {

        yield return new WaitForSeconds(3); 
        enemy.SetActive(false);
        spawnNum = Random.Range(0, spawnZones.Length);
        enemyNum = Random.Range(0, enemies.Length);
        enemy = enemies[enemyNum];
        enemySpawn = spawnZones[spawnNum];

        enemy.transform.position = enemySpawn.transform.position;
        enemy.SetActive(true);
    }
}
