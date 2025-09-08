using UnityEngine;
using UnityEngine.Events;

public class RoundManager : MonoBehaviour
{
    private int _currentEnemyCount = 0;
    private int _currentRoundPower = 0;

    public UnityAction<int> RoundStarted;
    public UnityAction<int> CurrentEnemiesCountChanged;

    private void OnStartedRound(int initialRoundPower)
    {
        _currentEnemyCount = initialRoundPower;

        CurrentEnemiesCountChanged?.Invoke(_currentEnemyCount);
        RoundStarted?.Invoke(initialRoundPower);
    }

    private void OnEnemyDead(GameObject enemy)
    {
        _currentEnemyCount -= 1;
        Debug.Log($"Enemy died. Remaining: {_currentEnemyCount}");
        CurrentEnemiesCountChanged?.Invoke(_currentEnemyCount);

        var obstacle = enemy.GetComponent<Obstacle>();
        obstacle.GetPool().Return(enemy);

        if (_currentEnemyCount <= 0)
        {
            RoundEnded?.Invoke();
        }
    }

    [SerializeField] private RoundStarter _roundStarter;

    private void OnEnable()
    {
        _roundStarter.RoundStarted += OnStartedRound;
        EnemyHealth.Dead += OnEnemyDead;
    }

    private void OnDisable()
    {
        _roundStarter.RoundStarted -= OnStartedRound;
        EnemyHealth.Dead -= OnEnemyDead;
    }

    public event System.Action RoundEnded;
}
