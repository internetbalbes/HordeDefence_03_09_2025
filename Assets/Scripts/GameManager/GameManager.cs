using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;

    public event System.Action GameStarted;

    private void Start()
    {
        _startGameButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(StartGame);
    }

    public void StartGame()
    {
        GameStarted?.Invoke();
    }
}
