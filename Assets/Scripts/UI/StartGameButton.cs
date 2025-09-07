using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        _gameManager.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _gameManager.GameStarted -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        gameObject.SetActive(false);
    }
}
