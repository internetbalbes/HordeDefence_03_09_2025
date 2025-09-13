using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private static Run _run;

    private void Start()
    {
        _run = FindFirstObjectByType<Run>();
    }

    private void OnEnable()
    {
        _run.Stopped += OnRunStopped;
    }

    private void OnDisable()
    {
        _run.Stopped -= OnRunStopped;
    }

    private void OnRunStopped()
    {
        Destroy(gameObject);
    }
}

