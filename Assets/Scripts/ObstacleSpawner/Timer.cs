using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Run _run;

    private bool _isRunning = false;

    public event Action Updated;

    private float _timer;
    private float _duration = 1f;
    private float _currentDuration;

    private void Update()
    {
        if (!_isRunning) return;

        _timer += Time.deltaTime;

        if (_timer >= _currentDuration)
        {
            _timer = 0f;

            _currentDuration = _duration;

            Updated?.Invoke();
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
    }
}
