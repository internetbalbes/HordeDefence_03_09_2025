using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Pool))]

public class Spawner : MonoBehaviour
{
    public static UnityAction<GameObject> ObstacleSpawned;

    [SerializeField] private RoundManager _roundManager;

    private Pool _pool => GetComponent<Pool>();

    [SerializeField] private Vector2 _spawnDelayRange = new Vector2(0.25f, 0.75f);

    private float _timeToSpawn = 0;
    private float _timer;

    private int _spawnedCount;
    private int _targetCount;

    private bool _isSpawning = false;

    private void StartSpawning(int roundPower)
    {
        _isSpawning = true;
        _targetCount = roundPower;
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
        GameObject obstacle = _pool.Get();
        _spawnedCount++;
        obstacle.GetComponent<Obstacle>().Initialize(_pool);
        ObstacleSpawned?.Invoke(obstacle);
        obstacle.SetActive(true);
    }

    private void ResetSpawnTimer()
    {
        _timeToSpawn = Random.Range(_spawnDelayRange.x, _spawnDelayRange.y);
    }

    private void OnEnable() => _roundManager.RoundStarted += StartSpawning;
    private void OnDisable() => _roundManager.RoundStarted -= StartSpawning;
}
