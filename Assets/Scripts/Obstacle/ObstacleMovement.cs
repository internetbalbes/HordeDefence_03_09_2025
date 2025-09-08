using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    protected const float Speed = 8f;

    void FixedUpdate()
    {
        transform.position += -transform.forward * Speed * Time.deltaTime;
    }
}
