using UnityEngine;
using UnityEngine.Events;

public class RoundManager : MonoBehaviour
{
    private int _roundPowerPoints = 15;
    private int _roundPowerPointsLeftToEliminate = 0;

    private const float RoundPowerMultiplier = 1.25f;

    public EnemySpawner enemySpawner;

    public UnityAction<int> _roundPowerPointsLeftToEliminateChanged;

    private void Start()
    {
        InitPointsToEliminate();


        for (int i = 0; i < _roundPowerPoints; i++)
        {
            enemySpawner.NewPawn();
        }

        enemySpawner.StartRound(_roundPowerPoints);
    }

    public int GetRoundPowerPointsToEliminate()
    {
        return _roundPowerPointsLeftToEliminate;
    }

    private void OnEnable() => Pawn.OnPawnKilled += OnPawnKilled;
    private void OnDisable() => Pawn.OnPawnKilled -= OnPawnKilled;

    private void OnPawnKilled(GameObject pawn)
    {
        enemySpawner.Enqueue(pawn);

        _roundPowerPointsLeftToEliminate--;
        _roundPowerPointsLeftToEliminateChanged?.Invoke(_roundPowerPointsLeftToEliminate);

        if (_roundPowerPointsLeftToEliminate > 0)
            return;

        enemySpawner.StartRound(_roundPowerPoints);
        _roundPowerPoints = Mathf.RoundToInt(_roundPowerPoints * RoundPowerMultiplier);

        InitPointsToEliminate();
    }

    private void InitPointsToEliminate()
    {
        _roundPowerPointsLeftToEliminate = _roundPowerPoints;
        _roundPowerPointsLeftToEliminateChanged?.Invoke(_roundPowerPointsLeftToEliminate);
    }
}
