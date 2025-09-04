using UnityEngine;
public class LootCrateMovement : MonoBehaviour
{
    private const float Speed = 5f;

    private CharacterController _controller;

    private void Start() => _controller = GetComponent<CharacterController>();
    
    void FixedUpdate()
    {
        _controller.Move(-transform.forward * Speed * Time.deltaTime);
    }
}
