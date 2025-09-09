using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Pool))]
[RequireComponent(typeof(Timer))]

public class TimeredSpawner : Spawner
{
    [SerializeField] private Run _run;

    private bool _isRunning = false;

    private Timer _timer => GetComponent<Timer>();

    private void OnTimerComplete()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _timer.Complete += OnTimerComplete;
        _run.Started += OnRunStarted;
    }

    private void OnDisable()
    {
        _timer.Complete -= OnTimerComplete;
        _run.Started -= OnRunStarted;
    }

    private void OnRunStarted()
    {
        Debug.Log("TimeredSpawnStarted");
        _isRunning = true;
        _timer.StartTimer();
    }
}
