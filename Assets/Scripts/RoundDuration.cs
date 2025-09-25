using UnityEngine;
using UnityEngine.Events;

public class RoundDuration : MonoBehaviour
{
    [SerializeField] private Run _run;

    public event UnityAction Changed;

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

            Changed?.Invoke();
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
        _roundDuration = 0;
        _isRunning = true;
        _timer = 0f;
        Changed?.Invoke();
    }

    private void OnRunStopped()
    {
        _isRunning = false;
        _timer = 0f;
        _roundDuration = 0;
        Changed?.Invoke();
    }
}
