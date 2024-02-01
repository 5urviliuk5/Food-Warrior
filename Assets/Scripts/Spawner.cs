using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public float spawnRadius = 2f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnFruit();
            nextSpawnTime = Time.time + 0.4f;
        }
    }

    void SpawnFruit()
    {
        Vector3 randomSpawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
        randomSpawnPos.y = -1f;
        Instantiate(fruitPrefab, randomSpawnPos, Quaternion.identity);
    }
}
