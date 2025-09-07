using UnityEngine;

[RequireComponent(typeof(FloatingJoystick))
]
public class JoystickVisible : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private FloatingJoystick _joystick => GetComponent<FloatingJoystick>();

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
        _joystick.gameObject.SetActive(true);
    }

    private void Start()
    {
        _joystick.gameObject.SetActive(false);
    }
}
