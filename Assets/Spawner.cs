using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject redBallPrefab;
    public GameObject blueBallPrefab;
    public float spawnInterval = 0.5f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0f;
        }
    }

    void SpawnBall()
    {
        float screenY = Camera.main.orthographicSize;
        float screenX = screenY * Camera.main.aspect;

        // Spawn right at the right edge (plus a tiny offset) with a random Y height
        Vector2 spawnPos = new Vector2(screenX + 1f, Random.Range(-screenY, screenY));

        int roll = Random.Range(0, 100);
        if (roll == 0 && blueBallPrefab != null)
        {
            Instantiate(blueBallPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(redBallPrefab, spawnPos, Quaternion.identity);
        }
    }
}