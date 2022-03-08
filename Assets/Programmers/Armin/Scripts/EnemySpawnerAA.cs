using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerAA : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    private int m_RandEnemy;

    private void Start() {
        StartCoroutine(WaitSpawner());
    }

    private void Update() {
        spawnWait = Random.Range(spawnMostWait, spawnMostWait);
    }

    IEnumerator WaitSpawner() {
        yield
            return new WaitForSeconds(startWait);

        while (!stop) {
            m_RandEnemy = Random.Range(0, 2);

            var spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1f, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[m_RandEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield
                return new WaitForSeconds(spawnWait);
        }
    }
}
