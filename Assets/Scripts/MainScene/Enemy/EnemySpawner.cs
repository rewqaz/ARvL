using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float MaxSpawnTime;
    [SerializeField]
    private float MinSpawnTime;
    [SerializeField]
    private GameObject enemyPrefab;
    float timeUntilSpawn;
    // Start is called before the first frame update
    void Start()
    {
        TimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if(timeUntilSpawn <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            TimeUntilSpawn();
        }
    }
    void TimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(MinSpawnTime, MaxSpawnTime);
    }
}
