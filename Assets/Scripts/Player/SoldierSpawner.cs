using UnityEngine;
using System;
using System.Collections.Generic;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _soldierPrefab;
    [SerializeField] private Run _run;
    [SerializeField] private Spawner _spawner;

    private int _soldiersMaximumAmount = 32;

    public List<GameObject> _soldiers = new List<GameObject>();

    public event Action AllSoldiersDead;
    public event Action SoldiersAmountChanged;
    public event Action AmountLimiterTriggered;

    public void RegisterEnemy(EnemyHealth enemy)
    {
        enemy.Dead += OnEnemyDead;
    }

    private void OnEnemyDead(EnemyHealth enemy)
    {
        AddSoldier();

        enemy.Dead -= OnEnemyDead;
    }

    public void AddSoldier()
    {
        if (_soldiers.Count < _soldiersMaximumAmount)
        {
            GameObject soldier = Instantiate(_soldierPrefab, Vector3.zero, Quaternion.identity);
            _soldiers.Add(soldier);

            SoldiersAmountChanged?.Invoke();
        }
        else
        {
            AmountLimiterTriggered?.Invoke();
        }
    }

    internal void RemoveAtSoldier(GameObject soldier)
    {
        _soldiers.Remove(soldier);
        Destroy(soldier);
        if (_soldiers.Count == 0)
            AllSoldiersDead?.Invoke();

        SoldiersAmountChanged?.Invoke();
    }

    public void RemoveSoldier()
    {
        if (_soldiers.Count == 0) return;

        GameObject soldier = _soldiers[0];
        _soldiers.RemoveAt(0);
        Destroy(soldier);

        if (_soldiers.Count == 0)
            AllSoldiersDead?.Invoke();

        SoldiersAmountChanged?.Invoke();
    }

    public void Multiply(int multiplier)
    {
        if (multiplier < 1) return;
        int change = _soldiers.Count * (multiplier - 1);
        ChangeSoldierCount(change);
    }

    public void Divide(int divisor)
    {
        if (divisor < 1) return;
        int newCount = Mathf.FloorToInt((float)_soldiers.Count / divisor);
        int change = newCount - _soldiers.Count;
        ChangeSoldierCount(change);
    }

    public void ChangeSoldierCount(int change)
    {
        if (change > 0)
        {
            for (int i = 0; i < change; i++)
                AddSoldier();
        }
        else if (change < 0)
        {
            for (int i = 0; i < Mathf.Abs(change); i++)
                RemoveSoldier();
        }
    }

    private void OnRunStarted()
    {
        AddSoldier();
    }

    private void OnRunStopped()
    {
        foreach (var soldier in _soldiers)
            Destroy(soldier);

        _soldiers.Clear();
    }

    private void OnEnable()
    {
        _run.Started += OnRunStarted;
        _run.Stopped += OnRunStopped;
        _spawner.ObstacleSpawned += OnObstacleSpawned;
    }

    private void OnDisable()
    {
        _run.Started -= OnRunStarted;
        _run.Stopped -= OnRunStopped;
        _spawner.ObstacleSpawned -= OnObstacleSpawned;
    }

    private void OnObstacleSpawned(GameObject obj)
    {
        if (obj.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            RegisterEnemy(enemy);
        }
    }
}
