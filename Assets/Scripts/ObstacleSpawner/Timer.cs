using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Run _run;

    [SerializeField] private float _duration = 1f;

    private bool _isRunning = false;

    public event Action Updated;

    private float _timer;

    private void Update()
    {
        if (!_isRunning) return;

        _timer += Time.deltaTime;

        if (_timer >= _duration)
        {
            _timer = 0f;

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

    internal void IsRunning(bool isRunning)
    {
        _isRunning = isRunning;
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
