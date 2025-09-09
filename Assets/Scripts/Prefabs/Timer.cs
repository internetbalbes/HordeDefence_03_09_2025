using UnityEngine;

public class Timer : MonoBehaviour
{
    public event System.Action Complete;

    [SerializeField] private float _duration;

    private float _timer = 0f;

    private bool _isRunning = false;

    private void Update()
    {
        if (!_isRunning) return;

        _timer += Time.deltaTime;

        if (_timer >= _duration)
        {
            _timer = 0f;
            Complete?.Invoke();
        }
    }

    public void StartTimer()
    {
        _isRunning = true;
        _timer = 0f;
    }
    
    public void StopTimer()
    {
        _isRunning = false;
        _timer = 0f;
    }
}
