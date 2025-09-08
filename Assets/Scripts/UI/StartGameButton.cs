using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private RoundStarter _roundStarter;

    private void OnEnable()
    {
        _roundStarter.RoundStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _roundStarter.RoundStarted -= OnGameStarted;
    }

    private void OnGameStarted(int integer)
    {
        gameObject.SetActive(false);
    }
}
