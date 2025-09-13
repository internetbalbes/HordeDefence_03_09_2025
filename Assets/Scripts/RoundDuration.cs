using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RoundDurationDisplay))]

public class RoundDuration : MonoBehaviour
{
    [SerializeField] private Run _run;

    public event UnityAction<int> RoundDurationChanged;

    private bool _isRunning = false;

    public static int _roundDuration = 0;

    private float _timer = 0f;

    private void Update()
    {
        if (!_isRunning) return;

        _timer += Time.deltaTime;

        if (_timer >= 1)
        {
            _timer = 0f;

            _roundDuration++;

            RoundDurationChanged?.Invoke(_roundDuration);
        }
    }

    private void OnEnable()
    {
        _run.Started += OnRunStarted;
        _run.Stopped += OnRunStopped;
    }

    private void OnDisable()
    {
        _run.Started -= OnRunStarted;
        _run.Stopped -= OnRunStopped;
    }

    private void OnRunStarted()
    {
        _isRunning = true;
        _timer = 0f;
    }

    private void OnRunStopped()
    {
        _isRunning = false;
        _timer = 0f;
        _roundDuration = 0;
        RoundDurationChanged?.Invoke(_roundDuration);
    }
}
