using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float spread = 2f;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(
            Random.Range(-spread, spread),
            0,
            Random.Range(-spread, spread)
        );
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;
            Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, 0.5f);
            newPosition.y = 0.5f;
            transform.position = newPosition;
        }
    }
}