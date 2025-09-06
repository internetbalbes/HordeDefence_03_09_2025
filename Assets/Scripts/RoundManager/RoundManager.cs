using UnityEngine;
using UnityEngine.Events;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private EnemyPool pool;

    [Header("Round Settings")]
    [SerializeField] private int baseEnemyCount = 15;
    [SerializeField] private float growthMultiplier = 1.25f;

    private int _currentEnemyCount;
    private int _remainingEnemies;

    public UnityAction<int> OnEnemiesRemainingChanged;

    private void Start()
    {
        _currentEnemyCount = baseEnemyCount;
        pool.Prewarm(_currentEnemyCount);
        StartRound();
    }

    private void OnEnable() => Pawn.OnPawnKilled += HandlePawnKilled;
    private void OnDisable() => Pawn.OnPawnKilled -= HandlePawnKilled;

    private void StartRound()
    {
        _remainingEnemies = _currentEnemyCount;
        OnEnemiesRemainingChanged?.Invoke(_remainingEnemies);
        spawner.StartSpawning(_currentEnemyCount);
    }

    private void HandlePawnKilled(GameObject pawn)
    {
        pool.Return(pawn);

        _remainingEnemies--;
        OnEnemiesRemainingChanged?.Invoke(_remainingEnemies);

        if (_remainingEnemies <= 0)
        {
            _currentEnemyCount = Mathf.RoundToInt(_currentEnemyCount * growthMultiplier);
            pool.Prewarm(_currentEnemyCount);
            StartRound();
        }
    }
}
