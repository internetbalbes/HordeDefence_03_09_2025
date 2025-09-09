using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(RoundDurationDisplay))]

public class RoundDuration : MonoBehaviour
{
    [SerializeField] private Run _run;

    private int _roundDuration = 0;

    private Timer _timer => GetComponent<Timer>();

    public event UnityAction<int> RoundDurationChanged;

    private bool _isRunning = false;

    private void OnTimerComplete()
    {
        _roundDuration++;
        RoundDurationChanged?.Invoke(_roundDuration);
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
        _isRunning = true;
        _timer.StartTimer();
    }
}
