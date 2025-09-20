using UnityEngine;

public class PlayerFollowing : MonoBehaviour
{
    private Transform _player;
    private Vector3 _offset;

    public void SetOffset(Vector3 offset, Transform player)
    {
        _offset = offset;
        _player = player;
        UpdatePosition();
    }

    private void Update()
    {
        if (_player != null)
            UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = _player.position + _offset;
    }
}
