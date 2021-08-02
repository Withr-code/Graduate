using UnityEngine;


[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private PlayerInputHandler _inputHandler;
    private Rigidbody _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _inputHandler = GetComponent<PlayerInputHandler>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = _inputHandler.Input.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move(_direction);
    }

    private void Move(Vector2 direction)
    {
        Vector3 move = _moveSpeed * new Vector3(direction.x, 0, direction.y);

        _rigidbody.AddRelativeForce(_moveSpeed * move, ForceMode.Force);
    }
}
