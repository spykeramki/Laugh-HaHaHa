using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyCtrl> enemiesToSpawnWithIndexAsLevel;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (!gameManager.isGameOver)
        {
            yield return new WaitForSeconds(Random.Range(4f, 8f));

            int indexOfEnemyToSpawn = Random.Range(0, gameManager.CurrentLevel);

            EnemyCtrl spawnEnemy = Instantiate(enemiesToSpawnWithIndexAsLevel[indexOfEnemyToSpawn], transform.position, transform.rotation, transform);
        }
        if (gameManager.isGameOver)
        {
            StopCoroutine("SpawnEnemy");
        }

    }
}
