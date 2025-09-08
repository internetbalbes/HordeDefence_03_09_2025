using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(FloatingJoystick))
]
public class JoystickVisible : MonoBehaviour
{
    [SerializeField] private RoundStarter _roundStarter;

    private FloatingJoystick _joystick => GetComponent<FloatingJoystick>();

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
        _joystick.gameObject.SetActive(true);
    }

    private void Start()
    {
        _joystick.gameObject.SetActive(false);
    }
}
