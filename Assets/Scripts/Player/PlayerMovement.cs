using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    private const float MinAllowedPositionX = -2f;
    private const float MaxAllowedPositionX = 2f;
    private const float Speed = 8f;

    private void Update()
    {
        float moveX = _joystick.Horizontal * Speed * Time.deltaTime;

        transform.Translate(moveX, 0f, 0f);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, MinAllowedPositionX, MaxAllowedPositionX);
        transform.position = position;
    }
}
