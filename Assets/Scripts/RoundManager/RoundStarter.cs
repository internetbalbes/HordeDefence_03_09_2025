using UnityEngine;

public class RoundStarter : MonoBehaviour
{
    public event System.Action<int> RoundStarted;

    [SerializeField] private GameStarter _gameStarter;
    [SerializeField] private RoundManager _roundManager;

    private void OnEnable()
    {
        _gameStarter.GameStarted += StartRound;
        _roundManager.RoundEnded += StartRound;
    }

    private void OnDisable()
    {
        _gameStarter.GameStarted -= StartRound;
        _roundManager.RoundEnded -= StartRound;
    }

    private int _initialRoundPower = 15;
    private float _initialRoundPowerMultiplier = 1.25f;

    private void StartRound()
    {
        _initialRoundPower = Mathf.RoundToInt(_initialRoundPower * _initialRoundPowerMultiplier);
        RoundStarted?.Invoke(_initialRoundPower);
    }
}
