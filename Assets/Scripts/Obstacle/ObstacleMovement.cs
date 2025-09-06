using UnityEngine;

public class ObstacleMovement : Obstacle
{
    [SerializeField] protected const float Speed = 8f;
    
    private CharacterController _controller;

    private void Start() => _controller = GetComponent<CharacterController>();
 
    void FixedUpdate()
    {
        _controller.Move(-transform.forward * Speed * Time.deltaTime);
    }
}
