using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 0.5f;
    float minX = -9.9f;
    float maxX = 9.8f;
    float nextSpawnTime = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        bool spawnLeft = Random.value > 0.5f;
        float spawnX = spawnLeft ? minX : maxX;
        float spawnY = Random.Range(4f, 0f);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f));
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (!spawnLeft)
        {
            enemyScript.moveSpeed = -enemyScript.moveSpeed;
            enemyScript.moveDirection = Vector3.left;
        };
        

    }
}
