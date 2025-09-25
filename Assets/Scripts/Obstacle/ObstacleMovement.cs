using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 9f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.z = -_speed;
        _rigidbody.linearVelocity = velocity;
    }
}
