using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public Transform player;

    private float _followSpeed = 5f;
    private float _spread = 2f;

    private Vector3 _offset;

    void Start()
    {
        _offset = new Vector3(
            Random.Range(-_spread, _spread),
            0,
            Random.Range(-_spread, _spread)
        );
    }
    
    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _followSpeed * Time.deltaTime);
        }
    }
}
