using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]

public class PlayerLooking : MonoBehaviour
{
    [SerializeField] private float _lookSpeed;

    private PlayerInputHandler _inputHandler;
    private Vector2 _rotation;

    private void Awake()
    {
        _inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        _rotation = _inputHandler.Input.Player.Look.ReadValue<Vector2>();
        Look(_rotation);
    }

    private void Look(Vector2 rotation)
    {
        float scaledLookSpeed = _lookSpeed * Time.deltaTime;

        _rotation.y = rotation.x * scaledLookSpeed;
        _rotation.x = 0;

        transform.Rotate(_rotation);
    }
}
