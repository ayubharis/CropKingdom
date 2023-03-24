using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 minSpawnPoint;
    public Vector2 maxSpawnPoint;
    public float spawnPadding = 1f;
    public float spawningSpeed = 5f;
    public static bool spawner = false;
    
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawningSpeed);
    }

    private void SpawnEnemy()
    {
        if (spawner)
        {
            // Determine a random spawn point within the specified range
            float spawnX = Random.Range(minSpawnPoint.x, maxSpawnPoint.x);
            float spawnY = Random.Range(minSpawnPoint.y, maxSpawnPoint.y);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            // Ensure that the spawn point is off screen
            float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

            spawnPosition.x = Mathf.Clamp(spawnPosition.x, minX + spawnPadding, maxX - spawnPadding);
            spawnPosition.y = Mathf.Clamp(spawnPosition.y, minY + spawnPadding, maxY - spawnPadding);

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.OnClick += OnEnemyClick;
                enemyComponent.OnDeath += OnEnemyDeath;
            }
        }
    }

    private void OnEnemyClick(Enemy enemy)
    {
        enemy.Kill();
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemy.ChangeSprite();
    }

    public void ChangeSpawningSpeed(float newSpeed)
    {
        spawningSpeed = newSpeed;
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 1f, spawningSpeed);
        Debug.Log(spawningSpeed);
    }


}
