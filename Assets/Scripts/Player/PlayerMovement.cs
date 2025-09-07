using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private const float Speed = 8f;

    private const float MinAllowedPositionX = -3f;
    private const float MaxAllowedPositionX = 3f;

    public FloatingJoystick joystick;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;

    }

    private void FixedUpdate()
    {
        float moveInput = joystick.Horizontal;

        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.x = moveInput * Speed;
        _rigidbody.linearVelocity = velocity;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, MinAllowedPositionX, MaxAllowedPositionX);
        transform.position = position;
    }
}
