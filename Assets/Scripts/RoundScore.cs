using UnityEngine;
using UnityEngine.Events;

public class RoundScore : MonoBehaviour
{
    [SerializeField] private SoldierSpawner _soldierSpawner;
    [SerializeField] private RoundDuration _roundDuration;
    [SerializeField] private Run _run;

    public UnityAction<int> Changed;
    public UnityAction<int> Finished;

    private int _score = 0;

    private void OnEnable()
    {
        _soldierSpawner.AmountLimiterTriggered += OnAmountLimiterTriggered;
        _roundDuration.Changed += OnRoundDurationChanged;
        _run.Started += OnRunStarted;
        _run.Stopped += OnRunStopped;
    }

    private void OnDisable()
    {
        _soldierSpawner.AmountLimiterTriggered -= OnAmountLimiterTriggered;
        _roundDuration.Changed -= OnRoundDurationChanged;
        _run.Started -= OnRunStarted;
        _run.Stopped -= OnRunStopped;
    }

    private void OnAmountLimiterTriggered()
    {
        Add();
    }

    private void OnRoundDurationChanged()
    {
        Add();
    }

    private void Add()
    {
        _score++;
        Changed?.Invoke(_score);
    }

    private void OnRunStarted()
    {
        _score = 0;
        Changed?.Invoke(_score);
    }

    private void OnRunStopped()
    {
        Finished?.Invoke(_score);
        _score = 0;
        Changed?.Invoke(_score);
    }
}
