using UnityEngine;

public class LootCrateSpawner : MonoBehaviour
{
    [SerializeField] private LootCratePool pool;
    [SerializeField] private Transform spawnZone;
    [SerializeField] private Vector2 xRange = new Vector2(-3, 3);
    [SerializeField] private Vector2 spawnDelayRange = new Vector2(0, (0.25f * 15) / 2);
    [SerializeField] private int lottCratesPerRound = 0;

    private float _timer;
    private float _timeToSpawn;
    private int _spawnedCount;
    private int _targetCount;
    private bool _isSpawning;

    public void StartSpawning(int crateCount)
    {
        _spawnedCount = 0;
        _targetCount = crateCount;
        _isSpawning = true;
        ResetSpawnTimer();
    }

    private void ResetSpawnTimer()
    {
        _timeToSpawn = Random.Range(spawnDelayRange.x, spawnDelayRange.y);
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
        GameObject crate = pool.Get();

        Vector3 pos = new Vector3(
            Random.Range(xRange.x, xRange.y),
            spawnZone.position.y,
            spawnZone.position.z
        );

        crate.transform.position = pos;
        crate.SetActive(true);
        _spawnedCount++;
    }
}
