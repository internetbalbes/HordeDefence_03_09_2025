using UnityEngine;

public class Timer : MonoBehaviour
{
    public event System.Action Complete;

    [SerializeField] private float _duration;
    [SerializeField, Range(0f, 1f)] private float _variation = 0.3f; // разброс в процентах (0.3 = 30%)

    private float _timer = 0f;
    private float _currentDuration;
    private bool _isRunning = false;

    private void Update()
    {
        if (!_isRunning) return;

        _timer += Time.deltaTime;

        if (_timer >= _currentDuration)
        {
            _timer = 0f;
            Complete?.Invoke();
            ResetDuration();
        }
    }

    public void StartTimer()
    {
        _isRunning = true;
        _timer = 0f;
        ResetDuration();
    }

    public void StopTimer()
    {
        _isRunning = false;
        _timer = 0f;
    }

    private void ResetDuration()
    {
        float min = _duration * (1f - _variation);
        float max = _duration * (1f + _variation);
        _currentDuration = Random.Range(min, max);
    }
}
