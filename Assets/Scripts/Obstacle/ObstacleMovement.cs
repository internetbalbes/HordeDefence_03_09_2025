using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private const float Speed = 6f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;

    }

    private void FixedUpdate()
    {
        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.z = -Speed;
        _rigidbody.linearVelocity = velocity;
    }
}
