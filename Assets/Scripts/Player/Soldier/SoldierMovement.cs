using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    private static GameObject _player;
    private Vector3 _offset;
    private float _spread = 3f;
    private float _speed = 5f;

    public static void SetPlayer(GameObject player) => _player = player;

    private void Start()
    {
        _offset = new Vector3(Random.Range(-_spread, _spread), 0f, Random.Range(-_spread, _spread));
        transform.position = _player.transform.position + _offset;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime * _speed);
    }
}