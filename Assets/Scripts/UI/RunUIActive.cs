using UnityEngine;

public class RunUIActive : MonoBehaviour
{
    [SerializeField] private Run _run;

    private void Awake()
    {
        _run.Started += OnRunStarted;
        _run.Stopped += OnRunStopped;
    }

    private void OnDestroy()
    {
        _run.Started -= OnRunStarted;
        _run.Stopped -= OnRunStopped;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnRunStarted()
    {
        gameObject.SetActive(true);
    }

    private void OnRunStopped()
    {
        gameObject.SetActive(false);
    }
}
