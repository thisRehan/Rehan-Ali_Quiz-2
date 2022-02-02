using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private int noOfEnemy;
    private int enemySpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        spawn();

    }
    void spawn()
    {
         noOfEnemy = FindObjectsOfType<EnemyController>().Length;
         if (noOfEnemy == 0 && enemySpawned < 15)
         {
             Instantiate(enemy, spawnPosition(), enemy.transform.rotation);
             enemySpawned++;
         }
    }
    Vector3 spawnPosition()
    {
        float xRange = 8;
        float zRange = 8;
        float xRandom = Random.Range(-xRange, xRange);
        float zRandom = Random.Range(-zRange, zRange);
        Vector3 randomPosition = new Vector3(xRandom, 0, zRandom);
        return randomPosition;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(60);
        if (enemySpawned == 15 && noOfEnemy == 0)
            Debug.Log("Player won the Game");
        else
            Debug.Log("Player Lose the Game");
    }
}
