using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _aimMask;
    [SerializeField] private ParticleSystem _crosshair;
    [Space]
    [Range(0, 30)] [SerializeField] private float _maxDistance;
    [SerializeField] private float _rotationSpeed;

    private PlayerInputHandler _inputHandler;
    private Vector2 _mouseScreenPosition;
    private Ray _aimDirection;

    private void Awake()
    {
        _inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        _mouseScreenPosition = _inputHandler.Input.Player.MousePosition.ReadValue<Vector2>();

        Aim(_mouseScreenPosition);
    }

    private void Aim(Vector2 mousePosition)
    {
        _aimDirection = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(_aimDirection, out RaycastHit hit, _maxDistance, _aimMask) && Time.timeScale > 0)
        {
            _crosshair.gameObject.SetActive(true);
            _crosshair.transform.position = hit.point;
            _crosshair.transform.rotation = Quaternion.FromToRotation(_crosshair.transform.forward, hit.normal) * _crosshair.transform.rotation;
        }
        else
        {
            _crosshair.gameObject.SetActive(false);
        }
    }

    public void Shoot()
    {
        if (Physics.Raycast(_aimDirection, out RaycastHit hit, _maxDistance, _aimMask) && Time.timeScale > 0)
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                transform.LookAt(enemy.transform);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

                enemy.GetDamage();
            }
    }
}
