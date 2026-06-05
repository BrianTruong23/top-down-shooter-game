using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRate = 10f;
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
            SpawnMeteor();
            nextSpawnTime = Time.time + spawnRate;
        }
        
    }

    void SpawnMeteor()
    {
        float spawnX = Random.Range(minX, maxX);
        float spawnY = Random.Range(0f, -2f);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        Instantiate(meteorPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f));

    }
}
