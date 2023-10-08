using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int numberOfEnemy = 10;
    public float spacing = 0.5f;
    public Transform spawnPoint;

    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Update is called once per frame
    private void SpawnEnemy(){
        for (int i = 0; i < numberOfEnemy; i++)
        {
            Vector3 offset = Vector3.right * (i * spacing - (spacing * (numberOfEnemy - 1) * 0.5f));
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position + offset , Quaternion.identity);
            enemy.transform.parent = transform;
        }
    }
}
