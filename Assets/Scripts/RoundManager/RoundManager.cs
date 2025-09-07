using UnityEngine;
using UnityEngine.Events;

public class RoundManager : MonoBehaviour
{
    private int _roundPower = 15;
    private int _currentEnemyCount = 0;
    private float _roundPowerMultiplier = 1.25f;

    public UnityAction<int> RoundStarted;
    public UnityAction<int> CurrentEnemiesCountChanged;

    private void OnRoundStarted()
    {
        _roundPower = Mathf.RoundToInt(_roundPower * _roundPowerMultiplier);
        _currentEnemyCount = _roundPower;
        CurrentEnemiesCountChanged?.Invoke(_currentEnemyCount);
        RoundStarted?.Invoke(_roundPower);
    }

    private void OnEnemyDead(GameObject enemy)
    {
        Debug.Log("Enemy dead");
        _currentEnemyCount--;
        enemy.SetActive(false);
        enemy.GetComponent<Obstacle>().GetPool().Return(enemy);

        if (_currentEnemyCount <= 0)
        {
            OnRoundStarted();
        }
        
        CurrentEnemiesCountChanged?.Invoke(_currentEnemyCount);
    }

    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        _gameManager.GameStarted += OnRoundStarted;
        EnemyHealth.Dead += OnEnemyDead;
    }

    private void OnDisable()
    {
        _gameManager.GameStarted -= OnRoundStarted;
        EnemyHealth.Dead -= OnEnemyDead;
    }
}
