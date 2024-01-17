using UnityEngine;

class Spawner : MonoBehaviour
{
    public GameObject stalactitePrefab;
    public float spawnRate = 2f;
    public float stalactiteHeight = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnStalactite), 0f, spawnRate);
    }

    void SpawnStalactite()
    {
        float randomY = Random.Range(0f, 2.5f) * stalactiteHeight;
        Instantiate(stalactitePrefab, new Vector3(transform.position.x, randomY, 0f), Quaternion.identity);
    }
}