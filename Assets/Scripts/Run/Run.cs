using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class Run : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private SoldierSpawner _soldierSpawner;
    [SerializeField] private EndZoneCollision _endZoneCollision;

    internal event Action Started;
    internal event Action Stopped;

    public static Run Instance;

    private void Awake()
    {
        Instance = this;
    }

    internal void StartRun()
    {
        Started?.Invoke();
    }

    public void Stop()
    {
        Stopped?.Invoke();
    }

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(StartRun);
        _soldierSpawner.AllSoldiersDead += Stop;
        _endZoneCollision.EnemyCollidedEndZone += Stop;
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(StartRun);
        _soldierSpawner.AllSoldiersDead -= Stop;
        _endZoneCollision.EnemyCollidedEndZone -= Stop;
    }
}
