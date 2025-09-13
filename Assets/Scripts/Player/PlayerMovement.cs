using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    private Rigidbody _rigidbody;

    private const float MinAllowedPositionX = -4f;
    private const float MaxAllowedPositionX = 4f;
    private const float Speed = 8f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = false;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.x = _joystick.Horizontal * Speed;
        _rigidbody.linearVelocity = velocity;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, MinAllowedPositionX, MaxAllowedPositionX);
        transform.position = position;
    }
}
