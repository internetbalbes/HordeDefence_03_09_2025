using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    private static GameObject _player;

    public static void SetPlayer(GameObject player)
    {
        _player = player;
    }

    public GameObject GetPlayer()
    {
        return _player;
    }

    private float _spread = 3f;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(
            Random.Range(-_spread, _spread),
            0,
            Random.Range(-_spread, _spread)
        );
    }

    void Update()
    {
        Vector3 targetPosition = _player.transform.position + offset;
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, 0.5f);
        newPosition.y = 0.5f;
        transform.position = newPosition;
    }
}