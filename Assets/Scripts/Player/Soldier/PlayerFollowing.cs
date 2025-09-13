using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerFollowing : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private static GameObject _player;

    private Vector3 _offset;

    private float _spread = 3f;

    private void Start()
    {
        _rigidbody.freezeRotation = true;
        _rigidbody.useGravity = false;

        _offset = new Vector3(Random.Range(-_spread, _spread), 0.5f, Random.Range(-_spread, _spread));
        transform.position = _player.transform.position + _offset;
    }

    internal void SetPlayer(GameObject player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = _player.transform.position;
        Vector3 velocity = Vector3.zero;
        _rigidbody.position = Vector3.SmoothDamp(_rigidbody.position, targetPosition, ref velocity, 0.1f);
    }
}
