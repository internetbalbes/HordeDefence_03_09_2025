using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool pool;
    [SerializeField] private Transform spawnZone;
    [SerializeField] private Vector2 xRange = new Vector2(-3, 3);
    [SerializeField] private Vector2 spawnDelayRange = new Vector2(0.25f, 0.75f);

    private float _timer;
    private float _timeToSpawn;
    private int _spawnedCount;
    private int _targetCount;
    private bool _isSpawning;

    public void StartSpawning(int enemyCount)
    {
        _spawnedCount = 0;
        _targetCount = enemyCount;
        _isSpawning = true;
        ResetSpawnTimer();
    }

    private void Update()
    {
        if (!_isSpawning) return;

        _timer += Time.deltaTime;
        if (_timer >= _timeToSpawn)
        {
            Spawn();
            _timer = 0f;
            ResetSpawnTimer();

            if (_spawnedCount >= _targetCount)
                _isSpawning = false;
        }
    }

    private void Spawn()
    {
        GameObject pawn = pool.Get();

        Vector3 pos = new Vector3(
            Random.Range(xRange.x, xRange.y),
            spawnZone.position.y,
            spawnZone.position.z
        );

        pawn.transform.position = pos;
        pawn.SetActive(true);
        _spawnedCount++;
    }

    private void ResetSpawnTimer()
    {
        _timeToSpawn = Random.Range(spawnDelayRange.x, spawnDelayRange.y);
    }
}
