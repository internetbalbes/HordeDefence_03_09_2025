using UnityEngine;
using UnityEngine.UI;
using System;

public class Run : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;

    public event Action Started;

    public void StartGame()
    {
        Debug.Log("RunStartGame");
        Started?.Invoke();
    }

    private void OnEnable() => _startGameButton.onClick.AddListener(StartGame);
    private void OnDisable() => _startGameButton.onClick.RemoveListener(StartGame);
}
