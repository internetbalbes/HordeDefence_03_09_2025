using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private const float Speed = 5f;
    private const float MinAllowedPositionX = -7f;
    private const float MaxAllowedPositionX = 7f;
    public FloatingJoystick joystick;
    private CharacterController _controller;
    private void Start() => _controller = GetComponent<CharacterController>();
    private void FixedUpdate()
    {
        Vector3 move = transform.right * joystick.Horizontal;
        _controller.Move(move * Speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, MinAllowedPositionX, MaxAllowedPositionX);
        transform.position = pos;
    }
}
